﻿using kursachV1.Frame;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursachV1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            //добавить запрос на подтверждение
            this.Close();
        }

        private void docButton_Click(object sender, RoutedEventArgs e)
        {
            menuFrame.Content = null;
            menuFrame.NavigationService.Navigate(new Uri("/Frame/Dogovor.xaml", UriKind.Relative));
        }
    }
}
