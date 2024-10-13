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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            LoadData();
            LoadRole();
        }
        private void LoadData()
        {
            lvList.ItemsSource = PrnNvcContext.INSTANCE.Users.Include(role => role.Role).ToList();
        }
        private void LoadRole()
        {
            cbRole.ItemsSource = PrnNvcContext.INSTANCE.Roles.ToList();
            cbRole.DisplayMemberPath = "DisplayName";
            cbRole.SelectedItem = "Id";
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvList.SelectedItem is User selected)
            {
                cbRole.SelectedValue = selected.Role.Id;
            }
            else
            {
                cbRole.SelectedValue = null;
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                string displayName = txtDisplayName.Text;
                string userName = txtUserName.Text;
                string password = PasswordHelper.HashPasswordSHA1("123");
                int idRole = (int)cbRole.SelectedValue;
                if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Không được nhập tên rỗng ! ");
                }
                else
                {
                    User user = new User();
                    user.UserName = userName;
                    user.Password = password;
                    user.RoleId = idRole;
                    user.DisplayName = displayName;
                    PrnNvcContext.INSTANCE.Users.Add(user);
                    PrnNvcContext.INSTANCE.SaveChanges();
                    LoadData();
                    MessageBox.Show("Tạo tài khoản thành công mk mặc định : 123  ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                string displayName = txtDisplayName.Text;
                string userName = txtUserName.Text;
                int idRole = (int)cbRole.SelectedValue;
                if (lvList.SelectedItem is User selected)
                {
                    selected.DisplayName = displayName;
                    selected.RoleId = idRole;
                    selected.UserName = userName;
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
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvList.SelectedItem is User select)
                {
                    var Question = PrnNvcContext.INSTANCE.QnAs.Where(x => x.LectureId == select.Id || x.StudentId == select.Id).ToList();
                    PrnNvcContext.INSTANCE.QnAs.RemoveRange(Question);

                    var Ass = PrnNvcContext.INSTANCE.Assessments.Where(x => x.LectureId == select.Id || x.StudentId == select.Id).ToList();
                    PrnNvcContext.INSTANCE.Assessments.RemoveRange(Ass);

                    PrnNvcContext.INSTANCE.Users.Remove(select);
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
