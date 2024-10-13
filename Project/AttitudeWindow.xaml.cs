using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for AttitudeWindow.xaml
    /// </summary>
    public partial class AttitudeWindow : Window
    {
        public AttitudeWindow()
        {
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            lvList.ItemsSource = PrnNvcContext.INSTANCE.Attitudes.ToList();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            string displayName = txtDisplayName.Text;
            if (string.IsNullOrEmpty(displayName))
            {
                MessageBox.Show("Display Name dom't empty!");
                return;
            }
            Attitude quality = new Attitude();
            quality.DisplayName = displayName;
            PrnNvcContext.INSTANCE.Attitudes.Add(quality);
            PrnNvcContext.INSTANCE.SaveChanges();
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string displayName = txtDisplayName.Text;

                if (lvList.SelectedItem is Attitude selected)
                {
                    selected.DisplayName = displayName;

                    if (PrnNvcContext.INSTANCE.Entry(selected).State != EntityState.Modified)
                    {
                        PrnNvcContext.INSTANCE.Entry(selected).State = EntityState.Modified;
                    }
                    PrnNvcContext.INSTANCE.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không hợp lệ ! Ngưng tiến trình cập nhật");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvList.SelectedItem is Attitude select)
                {
                    var Ass = PrnNvcContext.INSTANCE.Assessments.Where(x => x.AttitudeId == select.Id).ToList();
                    PrnNvcContext.INSTANCE.Assessments.RemoveRange(Ass);

                    PrnNvcContext.INSTANCE.Attitudes.Remove(select);
                    PrnNvcContext.INSTANCE.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
