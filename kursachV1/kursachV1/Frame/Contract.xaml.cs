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
using System.Windows.Shapes;

namespace kursachV1.Frame
{
    /// <summary>
    /// Interaction logic for Contract.xaml
    /// </summary>
    public partial class Contract : System.Windows.Controls.UserControl
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Coverage_life coverageLife = new Coverage_life();
            coverageLife.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Сoverage_childs coverageChilds = new Сoverage_childs();
            coverageChilds.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Coverage_universal coverageUniversal = new Coverage_universal();
            coverageUniversal.Show();
        }
    }
}
