using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace kursachV1.Interface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Сoverage_childs : Window
    {
        SqlConnection sc;
      
        string[] installs = new string[] { "1996", "1997", "1998", "1999", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014" };
        string[] installs2 = new string[] { "Мужчины","Женщины" };
        public Сoverage_childs()
        {
            InitializeComponent();
            if (Sotryd._count == 2)
            {

                Dost_voz.IsEnabled = false;

            }
                DateTime d1 = DateTime.Now;
                DateTime d2 = new DateTime(2030,1,1);
                scr.Maximum = Convert.ToInt32(d2.Year);
                scr2.Maximum = Convert.ToInt32(d1.Year);
                scr4.Maximum = Convert.ToInt32(d1.Day);
                scr5.Maximum = 30;
            foreach (string i in installs)
            Godrag.Items.Add(i);
            foreach (string i in installs2)
                pol.Items.Add(i);
            smert.IsEnabled = false;
            invalid.IsEnabled = false;
            Vred_zdarov.IsEnabled = false;
            sc = new SqlConnection(Sotryd.myConnectionString);
            //sc = new SqlConnection(@"Data Source=PC-Maverick;Initial Catalog=Pro100;Integrated Security=True");
            sc.Open();
        }

        public spisok_vznosov_detei spisok_vznosov_detei
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public spisok_raschetov_deti spisok_raschetov_deti
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Klient Klient
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)e.OriginalSource;

            // Create an instance of the window named
            // by the current button.
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content);

            // Show the window.
            win.ShowDialog();
            data.Text = Klient2.day.ToString();
            month.Text = Klient2.month.ToString();

            foreach (string i in installs)
                if (i == Klient2.year.ToString())
                    Godrag.SelectedItem = i;
            foreach (string j in installs2)
                if (j == Klient2.Kpol)
                    pol.SelectedItem = j;

            Ndog2.Content =   Klient2.Ndogovor.ToString();
            this.Close();
        }

        private void OnScroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                god3.Text = Convert.ToString(scr.Value);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (month3.Text != "" && day3.Text != "" && month1.Text != "" && god1.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
           
        }

        private void god3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr.Value = Convert.ToUInt32(god3.Text);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (month3.Text != "" && day3.Text != "" && month1.Text != "" && god1.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll2(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                god1.Text = Convert.ToString(scr2.Value);
                if (month3.Text != "" && day3.Text != "" && month1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void god1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr2.Value = Convert.ToUInt32(god1.Text);
                if (month3.Text != "" && day3.Text != "" && month1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll3(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                month1.Text = Convert.ToString(scr3.Value);
                if (month3.Text != "" && day3.Text != "" && god1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void month1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr3.Value = Convert.ToUInt32(month1.Text);
                if (month3.Text != "" && day3.Text != "" && god1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll4(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                day1.Text = Convert.ToString(scr4.Value);
                if (month3.Text != "" && month1.Text != "" && god1.Text != "" && god3.Text != "" && day3.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void day1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr4.Value = Convert.ToUInt32(day1.Text);
                if (month3.Text != "" && month1.Text != "" && god1.Text != "" && god3.Text != "" && day3.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll5(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                day3.Text = Convert.ToString(scr5.Value);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (month3.Text != "" && month1.Text != "" && god1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void day3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr5.Value = Convert.ToUInt32(day3.Text);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (month3.Text != "" && month1.Text != "" && god1.Text != "" && god3.Text != "" && day1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll6(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                month3.Text = Convert.ToString(scr6.Value);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (day3.Text != "" && day1.Text != "" && god1.Text != "" && god3.Text != "" && month1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void month3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr6.Value = Convert.ToUInt32(month3.Text);
                ldata.Content = day3.Text + "." + month3.Text + "." + god3.Text;
                if (day3.Text != "" && day1.Text != "" && god1.Text != "" && god3.Text != "" && month1.Text != "")
                {
                    int god = Convert.ToInt32(god3.Text) - Convert.ToInt32(god1.Text);
                    int mes = 12 - Math.Abs((Convert.ToInt32(month3.Text) - Convert.ToInt32(month1.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let2.Text = god.ToString();
                    mesya2.Text = mes.ToString();
                    dni2.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll7(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                month.Text = Convert.ToString(scr7.Value);
                if (Godrag.SelectedItem != null && data.Text != "")
                {
                    DateTime d1 = DateTime.Now;
                    int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                    int mes = 12 - Math.Abs((Convert.ToInt32(d1.Month) - Convert.ToInt32(month.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(d1.Day) - Convert.ToInt32(data.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let.Text = god.ToString();
                    mesya.Text = mes.ToString();
                    dni.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void month_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr7.Value = Convert.ToUInt32(month.Text);
                if (Godrag.SelectedItem != null && data.Text != "")
                {
                    DateTime d1 = DateTime.Now;
                    int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                    int mes = 12 - Math.Abs((Convert.ToInt32(d1.Month) - Convert.ToInt32(month.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(d1.Day) - Convert.ToInt32(data.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let.Text = god.ToString();
                    mesya.Text = mes.ToString();
                    dni.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void OnScroll8(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            try
            {
                data.Text = Convert.ToString(scr8.Value);
                if (Godrag.SelectedItem != null && month.Text != "")
                {
                    DateTime d1 = DateTime.Now;
                    int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                    int mes = 12 - Math.Abs((Convert.ToInt32(d1.Month) - Convert.ToInt32(month.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(d1.Day) - Convert.ToInt32(data.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let.Text = god.ToString();
                    mesya.Text = mes.ToString();
                    dni.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void data_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                scr8.Value = Convert.ToUInt32(data.Text);
                if (Godrag.SelectedItem != null && month.Text != "")
                {
                    DateTime d1 = DateTime.Now;
                    int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                    int mes = 12 - Math.Abs((Convert.ToInt32(d1.Month) - Convert.ToInt32(month.Text)));
                    int den = (12 - mes) * 30 - Math.Abs((Convert.ToInt32(d1.Day) - Convert.ToInt32(data.Text)));
                    ldata2.Content = god + "." + mes + "." + den;
                    let.Text = god.ToString();
                    mesya.Text = mes.ToString();
                    dni.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void Godrag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (month.Text != "" && data.Text != "")
                {
                    DateTime d1 = DateTime.Now;
                    int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                    int mes = 12 - Math.Abs((Convert.ToInt32(d1.Month) - Convert.ToInt32(month.Text)));
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(d1.Day) - Convert.ToInt32(data.Text))));
                    ldata2.Content = god + "." + mes + "." + den;
                    let.Text = god.ToString();
                    mesya.Text = mes.ToString();
                    dni.Text = den.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime d1 = DateTime.Now;
            int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
            string ld;
            string ld2;
            string ld3;
            string ld4;
            ld = day3.Text + "." + month3.Text + "." + god3.Text;
            ld2 = day1.Text + "." + month1.Text + "." + god1.Text;
            ld3 = "Лет " + let2.Text + " Месяцев " + mesya2.Text + " Дней " + dni2.Text;
            ld4 = "Лет " + let.Text + " Месяцев " + mesya.Text + " Дней " + dni.Text;
            try
            {
                PaymentChildren pC = new PaymentChildren();
                pC._kodvznos = Convert.ToInt32(Nvznosa.Text);
                pC._dostVozr = Convert.ToInt32(Dost_voz.Text);
                pC._smert = Convert.ToInt32(Convert.ToDouble(smert.Text));
                pC._invalid = Convert.ToInt32(Convert.ToDouble(invalid.Text));
                pC._vredZdar = Convert.ToInt32(Convert.ToDouble(Vred_zdarov.Text));
                pC._obVznosPoDostV = Convert.ToInt32(Convert.ToDouble(Ob_vznos.Text));
                pC.InsertPaymentChildren(pC._dostVozr, pC._smert, pC._invalid, pC._vredZdar, pC._obVznosPoDostV, pC._kodvznos);
            }
            catch(Exception ex)
            { MessageBox.Show("Незаполнены правильно данные!" + ex.Message); }
            try
            {

                InsuranceOfChildren IoC = new InsuranceOfChildren();


                IoC._Nstavka = Convert.ToInt32(Nstavka.Text);
                IoC._pol = Convert.ToString(pol.SelectionBoxItem);
                IoC._Vozrast = god;
                IoC._valyta = Convert.ToString(Valyta.SelectionBoxItem);
                IoC._dataNachalasroka = Convert.ToDateTime(ld2);
                IoC._VozrastZastrx = ld4;
                IoC._dataOkonchaSroka = Convert.ToDateTime(ld);
                IoC._SrokStr = ld3;
                IoC._Pereodi = Convert.ToString(Period.SelectionBoxItem);
                IoC._skidki = Convert.ToString(skidki.SelectionBoxItem);
                IoC._kyrsVal = Convert.ToInt32(kyrs.Text);
                IoC._kodVznosa = Convert.ToInt32(Nvznosa.Text);
                IoC.InsertInsuranceOfChildren(IoC._Nstavka, IoC._Vozrast, IoC._pol, IoC._dataNachalasroka, IoC._dataOkonchaSroka, IoC._SrokStr, IoC._VozrastZastrx, IoC._valyta, IoC._Pereodi, IoC._skidki, IoC._kyrsVal, IoC._kodVznosa);
                if (Dost_voz.Text != "")
                {
                    string s1;
                    s1 = Dost_voz.Text;
                    Dost_voz.Text = "0";
                    Dost_voz.Text = s1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Внесены изменения в таблицу Взносы детей" + ex.Message);
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentChildren pC = new PaymentChildren();
                pC._kodvznos = Convert.ToInt32(Nvznosa.Text);
                pC._dostVozr = Convert.ToInt32(Dost_voz.Text);
                pC._smert = Convert.ToInt32(Convert.ToDouble(smert.Text));
                pC._invalid = Convert.ToInt32(Convert.ToDouble(invalid.Text));
                pC._vredZdar = Convert.ToInt32(Convert.ToDouble(Vred_zdarov.Text));
                pC._obVznosPoDostV = Convert.ToInt32(Convert.ToDouble(Ob_vznos.Text));
                pC.UpdatePaymentChildren(pC._dostVozr, pC._smert, pC._invalid, pC._vredZdar, pC._obVznosPoDostV, pC._kodvznos);
                if (Dost_voz.Text != "")
                {
                    string s1;
                    s1 = Dost_voz.Text;
                    Dost_voz.Text = "0";
                    Dost_voz.Text = s1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильно внесены данные для обновления" + ex.Message);
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            smert.Text = "0";
            smert.IsEnabled = false;
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            smert.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            invalid.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            invalid.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            Vred_zdarov.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            Vred_zdarov.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d1 = DateTime.Now;
                int god = Convert.ToInt32(d1.Year) - Convert.ToInt32(Godrag.SelectedItem);
                string ld;
                string ld2;
                string ld3;
                string ld4;
                ld = day3.Text + "." + month3.Text + "." + god3.Text;
                ld2 = day1.Text + "." + month1.Text + "." + god1.Text;
                ld3 = "Лет " + let2.Text + " Месяцев " + mesya2.Text + " Дней " + dni2.Text;
                ld4 = "Лет " + let.Text + " Месяцев " + mesya.Text + " Дней " + dni.Text;
                InsuranceOfChildren IoC = new InsuranceOfChildren();
                IoC._Nstavka = Convert.ToInt32(Nstavka.Text);
                IoC._pol = Convert.ToString(pol.SelectionBoxItem);
                IoC._Vozrast = god;
                IoC._valyta = Convert.ToString(Valyta.SelectionBoxItem);
                IoC._dataNachalasroka = Convert.ToDateTime(ld2);
                IoC._VozrastZastrx = ld4;
                IoC._dataOkonchaSroka = Convert.ToDateTime(ld);
                IoC._SrokStr = ld3;
                IoC._Pereodi = Convert.ToString(Period.SelectionBoxItem);
                IoC._skidki = Convert.ToString(skidki.SelectionBoxItem);
                IoC._kyrsVal = Convert.ToInt32(kyrs.Text);
                IoC._kodVznosa = Convert.ToInt32(Nvznosa.Text);
                IoC.UpdateInsuranceOfChildren(IoC._Nstavka, IoC._Vozrast, IoC._pol, IoC._dataNachalasroka, IoC._dataOkonchaSroka, IoC._SrokStr, IoC._VozrastZastrx, IoC._valyta, IoC._Pereodi, IoC._skidki, IoC._kyrsVal, IoC._kodVznosa);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильно внесены данные обновлений" + ex.Message);
            }
            
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            try
            {
                data.Text = Klient2.day.ToString();
                month.Text = Klient2.month.ToString();
                Nvznosa.Text = Klient2.Nvznosa.ToString();
                foreach (string i in installs)
                    if (i == Klient2.year.ToString())
                        Godrag.SelectedItem = i;
                foreach (string j in installs2)
                    if (j == Klient2.Kpol)
                        pol.SelectedItem = j;
                Ndog2.Content = Klient2.Ndogovor.ToString();


                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Взносы Where Код_взноса={0}", Nvznosa.Text);
                if (Nvznosa.Text != "0")
                {
                    using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        inv.Load(dr);
                        dr.Close();
                    }

                    Dost_voz.Text = inv.Rows[0][1].ToString();
                    if (Chsmert.IsChecked == true)
                        smert.Text = inv.Rows[0][2].ToString();
                    if (Chinvalid.IsChecked == true)
                        invalid.Text = inv.Rows[0][3].ToString();
                    if (ChVred_zdarov.IsChecked == true)
                        Vred_zdarov.Text = inv.Rows[0][4].ToString();
                    Ob_vznos.Text = inv.Rows[0][5].ToString();


                }




                if (Ndog2.Content.ToString() != "0")
                {
                    DataTable inv2 = new DataTable();
                    string sql2 = string.Format("Select * From Обслуживание_стр_детей Where Номер_договора={0}", Klient2.Ndogovor);
                    using (SqlCommand cmd = new SqlCommand(sql2, this.sc))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        inv2.Load(dr);
                        dr.Close();
                    }
                    if (inv2.Rows.Count != 0)
                    {

                        DateTime t1 = DateTime.Now;
                        DateTime t2 = new DateTime();
                        DateTime t3 = new DateTime();


                        int god;
                        god = Convert.ToInt32(t1.Year) - Convert.ToInt32(inv2.Rows[0][2].ToString());
                        month.Text = "1";
                        data.Text = "1";
                        Godrag.Text = god.ToString();
                        Nstavka.Text = inv2.Rows[0][1].ToString();

                        pol.Text = inv2.Rows[0][3].ToString();
                        t2 = Convert.ToDateTime(inv2.Rows[0][4].ToString());
                        t3 = Convert.ToDateTime(inv2.Rows[0][5].ToString());
                        day1.Text = Convert.ToString(t2.Day);
                        god1.Text = Convert.ToString(t2.Year);
                        month1.Text = Convert.ToString(t2.Month);
                        day3.Text = Convert.ToString(t3.Day);
                        god3.Text = Convert.ToString(t3.Year);
                        month3.Text = Convert.ToString(t3.Month);
                        Valyta.Text = inv2.Rows[0][8].ToString();
                        Period.Text = inv2.Rows[0][9].ToString();
                        skidki.Text = inv2.Rows[0][10].ToString();
                        kyrs.Text = inv2.Rows[0][11].ToString();
                        if (Nvznosa.Text == "0")
                            Nvznosa.Text = inv2.Rows[0][12].ToString();


                    }
                }

                if (Dost_voz.Text != "")
                {
                    string s1;
                    s1 = Dost_voz.Text;
                    Dost_voz.Text = "0";
                    Dost_voz.Text = s1;
                }
            }
            catch { }
        }

        private void Button_Click_98(object sender, RoutedEventArgs e)
        {
         spisok_vznosov_detei detp = new spisok_vznosov_detei();
            detp.Show();
        }

        private void Button_Click_raschet(object sender, RoutedEventArgs e)
        {
            spisok_raschetov_deti ras = new spisok_raschetov_deti();
            ras.Show();

            this.Close();
        }

        private void Changed_dos_voz(object sender, TextChangedEventArgs e)
        {
            try{
            Klient2.Nvznosa = Convert.ToInt32(Nvznosa.Text);
            if (skidki.SelectionBoxItem.ToString() != "" &&  Godrag.Text != "" && Period.SelectionBoxItem.ToString() != "" && pol.SelectionBoxItem.ToString() != "" && Valyta.Text != "" && Klient2.Nvznosa != 0)
            {
            double _ob = 0;
            double _ob2 = 0;
            double _ob3 = 0;
            double _ob4 = 0;
            if (Dost_voz.Text != "0")
            {

                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Ставка_детей Where Пол='{0}' AND Возраст={1}", pol.Text, Convert.ToInt32(let.Text));
                using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    inv.Load(dr);
                    dr.Close();
                }
                double limit = 0;
                double kye = 0;
                double lx = Convert.ToDouble(inv.Rows[0][2].ToString());
                double dx = Convert.ToDouble(inv.Rows[0][3].ToString());
                double bx = Convert.ToDouble(inv.Rows[0][4].ToString());
                double zx = Convert.ToDouble(inv.Rows[0][5].ToString());
                double hx = Convert.ToDouble(inv.Rows[0][6].ToString());
                double tarif = Math.Round(((lx / (dx + bx) / hx * 2 - 0.2 + 7) * 10), 3);
                if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                    limit = Convert.ToDouble(Dost_voz.Text);
                else
                {
                    limit = Convert.ToDouble(Dost_voz.Text) * Convert.ToDouble(kyrs.Text);
                    kye = limit;
                }
                Tdostizv.Text = tarif.ToString();
                double limit3 = tarif * limit / 100;
                double letr = Convert.ToDouble(let.Text);
                double letr2 = Convert.ToDouble(let2.Text);
                Ldostizv.Text = limit3.ToString();
                tarif = Math.Round((100 - tarif) / 2 / 10, 3);

                if (Chsmert.IsChecked == true)
                {
                    Tsmerti.Text = tarif.ToString();
                    double limi2 = tarif * limit / 100;
                    Lsmerti.Text = limi2.ToString();
                    limi2 = Math.Round(tarif * limit / letr / letr2, 3);
                    smert.Text = limi2.ToString();

                }

                tarif = Math.Round(tarif / 2, 3);
                if (Chinvalid.IsChecked == true)
                {
                    Tinval.Text = tarif.ToString();
                    double limi2 = tarif * limit / 100;
                    Linval.Text = limi2.ToString();
                    limi2 = Math.Round(tarif * limit / letr / letr2, 3);
                    invalid.Text = limi2.ToString();
                }

                tarif = Math.Round(tarif * zx / hx, 3);
                if (ChVred_zdarov.IsChecked == true)
                {
                    Tvrez.Text = tarif.ToString();
                    double limi2 = tarif * limit / 100;
                    Lvrez.Text = limi2.ToString();
                    limi2 = Math.Round(tarif * limit / letr / letr2, 3);
                    Vred_zdarov.Text = limi2.ToString();
                }
                if (Chsmert.IsChecked == true)
                {

                    _ob2 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(smert.Text);
                    Ob_vznos.Text = _ob2.ToString();

                }
                if (Chinvalid.IsChecked == true)
                {

                    _ob3 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(invalid.Text);

                }

                if (ChVred_zdarov.IsChecked == true)
                {

                    _ob4 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(Vred_zdarov.Text);

                }
                if (ChVred_zdarov.IsChecked == false && Chinvalid.IsChecked == false && Chsmert.IsChecked == false)
                    Ob_vznos.Text = Dost_voz.Text;

                //    _ob = _ob2 + Convert.ToDouble(Dost_voz.Text);
                //  Ob_vznos.Text = _ob.ToString();

                _ob = _ob2 + _ob3 + _ob4 + Convert.ToDouble(Dost_voz.Text);
                if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                    OBrazvznos.Text = _ob.ToString();
                else
                {
                    _ob = _ob * kye;
                    OBrazvznos.Text = _ob.ToString();
                }
                if (Period.SelectionBoxItem.ToString() == "единовременно")
                    OBvzpodogo.Text = _ob.ToString();
                else if (Period.SelectionBoxItem.ToString() == "ежегодно")
                {
                    _ob = _ob * 5;
                    OBvzpodogo.Text = _ob.ToString();
                }
                else if (Period.SelectionBoxItem.ToString() == "ежеквартально")
                {
                    _ob = _ob * 20;
                    OBvzpodogo.Text = _ob.ToString();
                }
                else if (Period.SelectionBoxItem.ToString() == "ежемесячно")
                {
                    _ob = _ob * 60;
                    OBvzpodogo.Text = _ob.ToString();
                }
                if (skidki.SelectionBoxItem.ToString() == "4_2")
                {
                    _ob = Convert.ToDouble(OBvzpodogo.Text) + 8;
                    Strax.Text = _ob.ToString();
                }
                else if (skidki.SelectionBoxItem.ToString() == "4_4")
                {
                    _ob = Convert.ToDouble(OBvzpodogo.Text) + 16;
                    Strax.Text = _ob.ToString();
                }
                else if (skidki.SelectionBoxItem.ToString() == "4_6")
                {
                    _ob = Convert.ToDouble(OBvzpodogo.Text) + 24;
                    Strax.Text = _ob.ToString();
                }
                else if (skidki.SelectionBoxItem.ToString() == "нет")
                {

                    Strax.Text = OBvzpodogo.Text;
                }


                double nalog;
                int round_val = 0;
                if (Convert.ToString(Valyta.SelectionBoxItem) == "Иностранная валюта")
                    round_val = 2;
                else
                    round_val = 0;
                nalog = Math.Round(Convert.ToDouble(OBvzpodogo.Text) * 0.12, round_val);
                Nalog_vichat.Text = nalog.ToString();

                double ставка, показатель;
                DataTable inv5 = new DataTable();
                string sql5 = string.Format("Select * From Ставка Where Номер_ставки={0}", 1);
                using (SqlCommand cmd = new SqlCommand(sql5, this.sc))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    inv5.Load(dr);
                    dr.Close();
                }

                if (Convert.ToString(Valyta.SelectionBoxItem) == "Иностранная валюта")
                {
                    round_val = 2;
                    ставка = Convert.ToDouble(inv5.Rows[0][3]) / 100;
                    показатель = Convert.ToDouble(inv5.Rows[0][1]) / 100;
                }
                else
                {
                    round_val = 0;
                    ставка = Convert.ToDouble(inv5.Rows[0][2]) / 100;
                    показатель = Convert.ToDouble(inv5.Rows[0][0]) / 100;
                }
                double KolVzno = 0;
                if (Period.SelectionBoxItem.ToString() == "единовременно")
                    KolVzno = 1;
                else if (Period.SelectionBoxItem.ToString() == "ежегодно")
                {
                    KolVzno = 5;
                }
                else if (Period.SelectionBoxItem.ToString() == "ежеквартально")
                {
                    KolVzno = 20;
                }
                else if (Period.SelectionBoxItem.ToString() == "ежемесячно")
                {
                    KolVzno = 60;
                }

                double Bonus = 0;


                double kelre = Convert.ToDouble(Dost_voz.Text);


                if ((ставка * показатель - 0.04) < 0)
                    Bonus = 0;
                else
                    for (int y = 1; y < KolVzno; y++)
                        Bonus = Bonus + (kelre * (1 - 0.04) * (ставка * показатель - 0.04) * y * 1 / KolVzno) / 100;
                Bonys.Text = Bonus.ToString();
            }

            }
            }
        
          catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }
        }

        private void Button_Click_YD(object sender, RoutedEventArgs e)
        {
            InsuranceOfChildren IoC = new InsuranceOfChildren();
            IoC.DeleteInsuranceOfChildren();
            
        }

        private void Button_Click_YDV(object sender, RoutedEventArgs e)
        {
            PaymentChildren pC = new PaymentChildren();

            pC.DeletePaymentChildren(Klient2.Nvznosa);
            
          
        }

        private void pol_DropDownClosed(object sender, EventArgs e)
        {
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void Valyta_DropDownClosed(object sender, EventArgs e)
        {
            if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                kyrs.IsEnabled = false;
            else
                kyrs.IsEnabled = true;


            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void skidki_DropDownClosed(object sender, EventArgs e)
        {
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void Period_DropDownClosed(object sender, EventArgs e)
        {
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void kyrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

 

        private void ClickBlank4(object sender, RoutedEventArgs e)
        {
            Process.Start(@"E:\PROG2\WPF\9781430243656\ProProjectVER_2\ProProjectVER_1\Assets\+Прилож 4. Договор ФЛ Пр № 5 с 03 01 2011.doc");
        }

      
       
       

       

      

      
     
        
       

    }
}
