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
    /// Interaction logic for AssessmentWindow.xaml
    /// </summary>
    public partial class AssessmentWindow : Window
    {
        private User User { get; set; }
        public AssessmentWindow(User user)
        {
            User = user;
            InitializeComponent();
            LoadComboBox();
            LoadData();

        }
        
        private void LoadData()
        {
            lvList.ItemsSource = PrnNvcContext.INSTANCE.Assessments.Include(ass => ass.Quality).Include(ass => ass.Attitude).Include(ass => ass.Lecture).Where(x => x.StudentId == User.Id).ToList();
        }
        private void LoadComboBox()
        {
            cbLecture.ItemsSource = PrnNvcContext.INSTANCE.Users.Where(u=>u.RoleId==2).ToList();
            cbLecture.DisplayMemberPath = "DisplayName";
            cbLecture.SelectedValuePath = "Id";
            cbQuality.ItemsSource = PrnNvcContext.INSTANCE.Qualities.ToList();
            cbQuality.DisplayMemberPath = "DisplayName";
            cbQuality.SelectedValuePath = "Id";
            cbAttiude.ItemsSource = PrnNvcContext.INSTANCE.Attitudes.ToList();
            cbAttiude.DisplayMemberPath = "DisplayName";
            cbAttiude.SelectedValuePath = "Id";
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var lectureId = cbLecture.SelectedValue;
                var attitudeId = cbAttiude.SelectedValue;
                var qualityId =  cbQuality.SelectedValue;
            if(lectureId == null || attitudeId == null || qualityId == null)
            {
                MessageBox.Show("Don't empty");
                return;
            }

                Assessment assessment = new Assessment();
                assessment.AttitudeId = (int)attitudeId;
                assessment.QualityId = (int)qualityId;
                assessment.LectureId = (int)lectureId;
                assessment.StudentId = User.Id;
                assessment.Commnet = txtComment.Text;
                assessment.CreateAt = DateOnly.FromDateTime(DateTime.Now);
                PrnNvcContext.INSTANCE.Assessments.Add(assessment);
                PrnNvcContext.INSTANCE.SaveChanges();
                LoadData();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvList.SelectedItem is Assessment select)
                {
                    var lectureId = cbLecture.SelectedValue;
                    var attitudeId = cbAttiude.SelectedValue;
                    var qualityId = cbQuality.SelectedValue;
                    select.AttitudeId = (int)attitudeId;
                    select.QualityId = (int)qualityId;
                    select.LectureId = (int)lectureId;
                    select.StudentId = User.Id;
                    select.Commnet = txtComment.Text;
                    if (PrnNvcContext.INSTANCE.Entry(select).State != EntityState.Modified)
                    {
                        PrnNvcContext.INSTANCE.Entry(select).State = EntityState.Modified;
                    }
                    PrnNvcContext.INSTANCE.SaveChanges();
                    LoadData();
                    MessageBox.Show("Update id : " + select.Id);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if(lvList.SelectedItem is Assessment select){
                cbAttiude.SelectedValue = select.Attitude.Id;
                cbLecture.SelectedValue = select.Lecture.Id;
                cbQuality.SelectedValue = select.Quality.Id;
            }
            else {
                MessageBox.Show("Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvList.SelectedItem is Assessment select)
                {
                    PrnNvcContext.INSTANCE.Assessments.Remove(select);
                    PrnNvcContext.INSTANCE.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
