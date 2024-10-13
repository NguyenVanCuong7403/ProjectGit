using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
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
    /// Interaction logic for AnswerWindow.xaml
    /// </summary>
    public partial class AnswerWindow : Window
    {
        private User user { get; set; }
        public AnswerWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadData();
        }
        private void LoadData()
        {
            lvList.ItemsSource = PrnNvcContext.INSTANCE.QnAs.Include(x=>x.Student).Where(x => x.LectureId == this.user.Id).ToList();
            txtTotal.Text = "Số câu hỏi chưa trả lời: "+PrnNvcContext.INSTANCE.QnAs.Count(x => x.LectureId == this.user.Id && x.Answer == null);
        }
        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (lvList.SelectedItem is QnA select)
            {
                select.Answer = txtAnswer.Text;
                if (PrnNvcContext.INSTANCE.Entry(select).State != EntityState.Modified)
                {
                    PrnNvcContext.INSTANCE.Entry(select).State = EntityState.Modified;
                }
                PrnNvcContext.INSTANCE.SaveChanges();
                LoadData();
            }
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvList.SelectedItem is QnA select)
            {
                txtQuestion.Text = select.Question;
                txtStudent.Text = "Student : "+select.Student.DisplayName+" ID: "+select.Student.Id;
            }
            else
            {
                txtQuestion.Text = "";
                txtStudent.Text = "Question and Anwser";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
