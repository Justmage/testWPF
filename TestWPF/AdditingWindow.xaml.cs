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
    /// ApplicationViewModel или "модель представления" связывает "модель" Employee и "представление" AdditingWindow через механизм привязки данных DataContext.
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
            this.DialogResult = true;
        }
    }
}
