﻿using System;
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

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для AdditingWindow.xaml
    /// </summary>
    public partial class AdditingWindow : Window
    {
        public AdditingWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            ((ApplicationViewModel)DataContext).AddEmployee();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}