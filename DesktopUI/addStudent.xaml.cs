﻿using DesktopUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for addStudent.xaml
    /// </summary>
    public partial class addStudent : Window
    {
        public addStudent(addStudentVM vM)
        {
            InitializeComponent();
            DataContext = vM;
            vM.close = () => Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
