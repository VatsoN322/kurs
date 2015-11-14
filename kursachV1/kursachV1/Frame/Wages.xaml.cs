using kursachV1.Interface;
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

namespace kursachV1.Frame
{
    /// <summary>
    /// Interaction logic for Wages.xaml
    /// </summary>
    public partial class Wages : UserControl
    {
        public Wages()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Wage_universal wageUniversal = new Wage_universal();
            wageUniversal.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Wage_statistics wageStatistics = new Wage_statistics();
            wageStatistics.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Wage wage = new Wage();
            wage.Show();
        }
    }
}
