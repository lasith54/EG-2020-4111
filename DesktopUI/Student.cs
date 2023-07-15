using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesktopUI.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BitmapImage Image { get; set; }
        public string DateofBirth { get; set; }
        public double GPA { get; set; }

        public string ImageURL
        {
            get
            {
                return $"/Images/{Image}";
            }
        }

        public Student(string firstName, string lastName, string dateofBirth, double gpa, BitmapImage image)
        {
            FirstName = firstName;
            LastName = lastName;
            DateofBirth = dateofBirth;
            GPA = gpa;
            Image = image;
        }

        public Student() { }
    }
}
