using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DesktopUI
{
    public partial class addStudentVM: ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;


        [ObservableProperty]
        public BitmapImage selectedImage;

        public Student user { get; private set; }
        public Action close { get; internal set; }


        public addStudentVM(Student stud)
        {
            user = stud;

            firstname = user.FirstName;
            lastname = user.LastName;
            dateofbirth = user.DateofBirth;
            gpa = user.GPA;
            selectedImage = user.Image;
            

        }

        public addStudentVM()
        {

        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if(dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image successfully uploded!", "Done");
            }
        }

        [RelayCommand]
        public void Save()
        {
            if(Gpa<0 || Gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error!");
                return;
            }
            if (user == null)
            {
                user = new Student()
                {
                    FirstName = Firstname,
                    LastName = Lastname,
                    DateofBirth = Dateofbirth,
                    Image = SelectedImage,
                    GPA = Gpa
                };
            }

            else
            {
                user.FirstName= Firstname;
                user.LastName= Lastname;
                user.DateofBirth= Dateofbirth;
                user.GPA= Gpa;
                user.Image = SelectedImage;
            }

            if(user.FirstName!= null)
            {
                close();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
