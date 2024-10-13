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
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private User User { get; set; }
        public QuestionWindow(User user)
        {
            this.User = user;
            InitializeComponent();
            LoadData();
            cbLecture.ItemsSource = PrnNvcContext.INSTANCE.Users.Where(u => u.RoleId == 2).ToList();
            cbLecture.DisplayMemberPath = "DisplayName";
            cbLecture.SelectedValuePath = "Id";
        }
        private void LoadData()
        {
            lvList.ItemsSource = PrnNvcContext.INSTANCE.QnAs.Where(x=>x.StudentId == this.User.Id).ToList();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var txtQues = txtQuestion.Text;
            if (txtQues == null)
            {
                MessageBox.Show("Không được để trống ô câu hỏi");
                return;
            }
            var lectureId = cbLecture.SelectedValue;
            if (lectureId == null)
            {
                MessageBox.Show("Vui lòng chọn giáo viên để hỏi đáp");
                return;
            }
            try
            {
                QnA qna = new QnA();
                qna.Question = txtQues;
                qna.LectureId = (int)lectureId;
                qna.StudentId = User.Id;
                qna.Answer = null;
                PrnNvcContext.INSTANCE.QnAs.Add(qna);
                PrnNvcContext.INSTANCE.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (lvList.SelectedItem is QnA select)
            {
                select.Question = txtQuestion.Text;
                select.LectureId = (int)cbLecture.SelectedValue;
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
            if(lvList.SelectedItem is QnA select) {
                cbLecture.SelectedValue = select.LectureId;
                if(select.Answer == null)
                {
                    txtans.Text = "Vui lòng chờ giảng viên đưa ra câu trả lời !";
                }else
                {
                    txtans.Text = "Answer : "+select.Answer;
                }
            }else
            {
                cbLecture.SelectedValue = null;
                txtans.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvList.SelectedItem is QnA select)
                {
                    PrnNvcContext.INSTANCE.QnAs.Remove(select);
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
