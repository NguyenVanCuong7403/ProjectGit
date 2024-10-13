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
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            QualityWindow qualityWindow = new QualityWindow();
            qualityWindow.ShowDialog();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AttitudeWindow attitudeWindow = new AttitudeWindow();
            attitudeWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();           
            loginWindow.ShowDialog();
        }
    }
}
