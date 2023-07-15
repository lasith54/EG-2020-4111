using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DesktopUI
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { SetProperty(ref selectedStudent, value); }
        }

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            BitmapImage img1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            students.Add(new Student("Kate", "Black", "12/12/1999", 2.95, img1));
            BitmapImage img2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            students.Add(new Student("Tim", "Henry", "22/05/1998", 3.35, img2));
            BitmapImage img3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            students.Add(new Student("Jimmy", "Nichols", "28/02/2000", 3.86, img3));
            BitmapImage img4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            students.Add(new Student("Ann", "Neesham", "31/08/1997", 3.65, img4));
            BitmapImage img5 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            students.Add(new Student("Sam", "Brown", "01/06/1998", 2.60, img5));
        }
        
        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                students.Remove(selectedStudent);
                MessageBox.Show("Deleted successfully.", "Deleted!");
            }
            else
            {
                MessageBox.Show("Plz select a student to delete.", "Error!");
            }
        }

        [RelayCommand]
        public void AddStudent()
        {
            var VM = new addStudentVM();
            addStudent window = new addStudent(VM);
            window.ShowDialog();

            
        }

        [RelayCommand]
        public void EditStudent()
        {
            if(selectedStudent != null)
            {
                var VM = new addStudentVM(selectedStudent);
                var window = new addStudent(VM);

                window.ShowDialog();

                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, VM.user);
            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        [RelayCommand]
        public void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void message()
        {
            MessageBox.Show($"{selectedStudent.FirstName} GPA should be between 0 and 4.", "Error!");
        }
    }
}
