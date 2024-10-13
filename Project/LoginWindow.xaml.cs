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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public User UserLogin { get; set; } = null;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Button_ClickLogin(object sender, RoutedEventArgs e)
        {

            string userName = txtUser.Text.Trim();
            string passWord = PasswordHelper.HashPasswordSHA1(txtPassWord.Password.Trim());
            UserLogin = PrnNvcContext.INSTANCE.Users.FirstOrDefault((user) => user.UserName.Equals(userName) && user.Password.Equals(passWord));
            if (UserLogin != null)
            {
                if(UserLogin.RoleId == 1)
                {
                    StudentWindow user = new StudentWindow(UserLogin);
                    this.Close();
                    user.Show();

                }else if (UserLogin.RoleId == 2)
                {
                    AnswerWindow aw = new AnswerWindow(UserLogin);
                    this.Close();
                    aw.Show();
                }
                else
                {
                    StaffWindow staffWindow = new StaffWindow();
                    this.Close();
                    staffWindow.Show();
                }

            }
            else
            {
                MessageBox.Show("Sai : " + passWord);
                Console.WriteLine(passWord);

            }


        }
    }
}
