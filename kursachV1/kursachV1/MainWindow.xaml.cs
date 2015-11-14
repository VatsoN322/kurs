using kursachV1.Frame;
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
            menuFrame.NavigationService.Navigate(new Uri("/Frame/Contract.xaml", UriKind.Relative));
        }

        private void stavkaButton_Click(object sender, RoutedEventArgs e)
        {
            menuFrame.Content = null;
            menuFrame.NavigationService.Navigate(new Uri("/Frame/Wages.xaml", UriKind.Relative));
        }

        private void othersButton_Click(object sender, RoutedEventArgs e)
        {
            Others others = new Others();
            others.ButtonClicked += others_Button_Click;
            menuFrame.Content = others;

        }
        private void others_Button_Click(object sender, EventArgs e)
        {
            menuFrame.Content = null;
            menuFrame.NavigationService.Navigate(new Uri("/Frame/Reports.xaml", UriKind.Relative));
        }
    }
}
