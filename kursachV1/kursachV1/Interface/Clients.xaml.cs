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

namespace kursachV1.Interface
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void Button_Clic_Menu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void Button_Click_24(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_562(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_YD(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_OB(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            /*VseKlient k = new VseKlient();
            lblError.Text = k.DateValidationError(sender, e);*/
        }
    }
}
