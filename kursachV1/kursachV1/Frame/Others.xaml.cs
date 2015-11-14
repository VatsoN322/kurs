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
    /// Interaction logic for Others.xaml
    /// </summary>
    public partial class Others : UserControl
    {
        public Others()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        public event EventHandler ButtonClicked;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
       
            if (ButtonClicked != null)
            {
                ButtonClicked(this, EventArgs.Empty);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clients client = new Clients();
            client.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employees employee = new Employees();
            employee.Show();

        }
    }
}
