using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace kursachV1.Interface
{
    /// <summary>
    /// Логика взаимодействия для Straxovanie_vzroslix.xaml
    /// </summary>
    public partial class Coverage_universal : Window
    {
        SqlConnection sc;
       int[] installs= new int[101] ;
 
        string[] installs2 = new string[] { "Мужчины", "Женщины" };
        public Coverage_universal()
        {
         /*   InitializeComponent();
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
            
             int y =0;
        for(int j=1900;j<=2000;j++)
        {
        installs[y] = j;
            y++;
        }
             foreach (int i in installs)
            Godrag.Items.Add(i);
            foreach (string i in installs2)
                pol.Items.Add(i);
            smert.IsEnabled = false;
            invalid.IsEnabled = false;
            Vred_zdarov.IsEnabled = false;
            sc = new SqlConnection(Sotryd.myConnectionString);
           // sc = new SqlConnection(@"Data Source=PC-Maverick;Initial Catalog=Pro100;Integrated Security=True");
            sc.Open();*/
        }


       /* public spisok_vznosov_vzroslix spisok_vznosov_vzroslix
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }*/

     /*   public spisok_raschetov_vzrosl spisok_raschetov_vzrosl
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }*/

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

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            invalid.Text = "0";
           
            Chinval_net.IsEnabled = false;
            invalid_in_nec.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Checked_19(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked_90(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked_200(object sender, RoutedEventArgs e)
        {
            Vrem_netryd.Text = "0";
            Vrem_netryd.IsEnabled = false;
            Chnetot_net.IsEnabled = true;
        }

        private void CheckBox_Checked_200(object sender, RoutedEventArgs e)
        {
            Vrem_netryd.Text = "0";
         

            Chnetot_net.IsEnabled = false;
            Vrem_netryd_in_nec.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Unchecked_201(object sender, RoutedEventArgs e)
        {
            smert_in_nec.Text = "0";
            smert_in_nec.IsEnabled = false;
            Chsmert.IsEnabled = true;
        }

        private void CheckBox_Checked_201(object sender, RoutedEventArgs e)
        {
            smert_in_nec.Text = "0";
           
            Chsmert.IsEnabled = false;
            smert.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Unchecked_202(object sender, RoutedEventArgs e)
        {
            invalid_in_nec.Text = "0";
            invalid_in_nec.IsEnabled = false;
            Chinvalid.IsEnabled = true;
        }

        private void CheckBox_Checked_202(object sender, RoutedEventArgs e)
        {
            invalid_in_nec.Text = "0";
            
            Chinvalid.IsEnabled = false;
            invalid.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void CheckBox_Unchecked_203(object sender, RoutedEventArgs e)
        {
            Vrem_netryd_in_nec.Text = "0";
            Vrem_netryd_in_nec.IsEnabled = false;
            ChVrem_net.IsEnabled = true;
        }

        private void CheckBox_Checked_203(object sender, RoutedEventArgs e)
        {
            Vrem_netryd_in_nec.Text = "0";
            ChVrem_net.IsEnabled = false;
            Vrem_netryd.Text = "0";
            if (Dost_voz.Text != "")
            {
                string s1;
                s1 = Dost_voz.Text;
                Dost_voz.Text = "0";
                Dost_voz.Text = s1;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
        /*    try
            {
                data.Text = Klient2.day.ToString();
                month.Text = Klient2.month.ToString();
                Nvznosa.Text = Klient2.Nvznosa.ToString();
                foreach (int i in installs)
                    if (i == Klient2.year)
                        Godrag.SelectedItem = i;
                foreach (string j in installs2)
                    if (j == Klient2.Kpol)
                        pol.SelectedItem = j;
                Ndog2.Content = Klient2.Ndogovor.ToString();


                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Взносы_взрослых Where Код_взносы={0}", Nvznosa.Text);
                if (Nvznosa.Text != "0")
                {
                    using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        inv.Load(dr);
                        dr.Close();
                    }

                    Dost_voz.Text = inv.Rows[0][2].ToString();
                    if (Chsmert.IsChecked == true)
                        smert.Text = inv.Rows[0][1].ToString();
                    if (Chinvalid.IsChecked == true)
                        invalid.Text = inv.Rows[0][3].ToString();
                    if (ChVred_zdarov.IsChecked == true)
                        Vred_zdarov.Text = inv.Rows[0][4].ToString();
                    if (ChVrem_net.IsChecked == true)
                        Vrem_netryd.Text = inv.Rows[0][5].ToString();
                    if (Chsmert_net.IsChecked == true)
                        smert_in_nec.Text = inv.Rows[0][6].ToString();
                    if (Chinval_net.IsChecked == true)
                        invalid_in_nec.Text = inv.Rows[0][7].ToString();
                    if (ChVrem_net.IsChecked == true)
                        Vrem_netryd_in_nec.Text = inv.Rows[0][8].ToString();
                    Ob_vznos.Text = inv.Rows[0][9].ToString();


                }



                if (Ndog2.Content.ToString() != "0")
                {
                    DataTable inv2 = new DataTable();
                    string sql2 = string.Format("Select * From Обслуживани_стр_взрослых Where Номер_договора={0}", Klient2.Ndogovor);
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
                        god = Convert.ToInt32(t1.Year) - Convert.ToInt32(inv2.Rows[0][3].ToString());
                        month.Text = "1";
                        data.Text = "1";
                        Godrag.Text = god.ToString();
                        Nstavka.Text = inv2.Rows[0][1].ToString();

                        pol.Text = inv2.Rows[0][2].ToString();
                        t2 = Convert.ToDateTime(inv2.Rows[0][9].ToString());
                        t3 = Convert.ToDateTime(inv2.Rows[0][10].ToString());

                        day1.Text = Convert.ToString(t2.Day);
                        god1.Text = Convert.ToString(t2.Year);
                        month1.Text = Convert.ToString(t2.Month);
                        day3.Text = Convert.ToString(t3.Day);
                        god3.Text = Convert.ToString(t3.Year);
                        month3.Text = Convert.ToString(t3.Month);

                        Valyta.Text = inv2.Rows[0][6].ToString();

                        Period.Text = inv2.Rows[0][8].ToString();
                        skidki.Text = inv2.Rows[0][11].ToString();
                        kyrs.Text = inv2.Rows[0][7].ToString();
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
            catch { }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* Button cmd = (Button)e.OriginalSource;

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

            foreach (int i in installs)
                if (i == Klient2.year)
                    Godrag.SelectedItem = i;
            foreach (string j in installs2)
                if (j == Klient2.Kpol)
                    pol.SelectedItem = j;

            Ndog2.Content = Klient2.Ndogovor.ToString();
            this.Close();*/

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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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
                    int den = Math.Abs((12 - mes) * 30 - Math.Abs((Convert.ToInt32(day3.Text) - Convert.ToInt32(day1.Text))));
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          /*  DateTime d1 = DateTime.Now;
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
                InsuranceOfAdults IoA = new InsuranceOfAdults();

                IoA._Nstavka = Convert.ToInt32(Nstavka.Text);
                IoA._pol = Convert.ToString(pol.SelectionBoxItem);
                IoA._Vozrast = Convert.ToString(god);
                IoA._valyta = Convert.ToString(Valyta.SelectionBoxItem);
                IoA._dataNachalasroka = Convert.ToDateTime(ld2);
                IoA._VozrastZastrx = ld4;
                IoA._dataOkonchaSroka = Convert.ToDateTime(ld);
                IoA._SrokStr = ld3;
                IoA._Pereodi = Convert.ToString(Period.SelectionBoxItem);
                IoA._skidki = Convert.ToString(skidki.SelectionBoxItem);
                IoA._kyrsVal = kyrs.Text;
                IoA._kodVznosa = Convert.ToInt32(Nvznosa.Text);
                IoA.UpdateInsuranceOfAdults(IoA._Nstavka, IoA._Vozrast, IoA._pol, IoA._dataNachalasroka, IoA._dataOkonchaSroka, IoA._SrokStr, IoA._VozrastZastrx, IoA._valyta, IoA._Pereodi, IoA._skidki, IoA._kyrsVal, IoA._kodVznosa);
             
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильно внесены данные" + ex.Message);
            }*/
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            smert.Text = "0";
            smert.IsEnabled = false;
            Chsmert_net.IsEnabled = true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            smert.Text = "0";
           
            Chsmert_net.IsEnabled = false;
            smert_in_nec.Text = "0";
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
            invalid.IsEnabled = false;
            Chinval_net.IsEnabled = true;
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            Vred_zdarov.Text = "0";
            Vred_zdarov.IsEnabled = false;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        /*    DateTime d1 = DateTime.Now;
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
                  ContributionsOfAdults CoA = new ContributionsOfAdults();
                CoA._kodvznos = Convert.ToInt32(Nvznosa.Text);
                CoA._dostVozr = Convert.ToInt32(Dost_voz.Text);
                CoA._smert = Convert.ToInt32(Convert.ToDouble(smert.Text));
                CoA._invalid = Convert.ToInt32(Convert.ToDouble(invalid.Text));
                CoA._vredZdar = Convert.ToInt32(Convert.ToDouble(Vred_zdarov.Text));
                CoA._obVznosPoDostV = Convert.ToInt32(Convert.ToDouble(Ob_vznos.Text));
                    CoA._NesSlsmert =Convert.ToInt32(Convert.ToDouble(smert_in_nec.Text));
        CoA._NesSlinvalid =Convert.ToInt32(Convert.ToDouble(invalid_in_nec.Text));
        CoA._vremenNetryd = Convert.ToInt32(Convert.ToDouble(Vrem_netryd.Text));
        CoA._NesSlvremenNetryd =Convert.ToInt32(Convert.ToDouble(Vrem_netryd_in_nec.Text));
                 CoA.InsertContributionsOfAdults(CoA._dostVozr, CoA._smert, CoA._invalid, CoA._vredZdar, CoA._obVznosPoDostV, CoA._kodvznos,CoA._NesSlsmert,CoA._NesSlinvalid, CoA._vremenNetryd,CoA._NesSlvremenNetryd);
            }
            catch(Exception ex)
              { MessageBox.Show("Незаполнены правильно данные!" + ex.Message); }

              try
              {
                  InsuranceOfAdults IoA = new InsuranceOfAdults();

                  IoA._Nstavka = Convert.ToInt32(Nstavka.Text);
                  IoA._pol = Convert.ToString(pol.SelectionBoxItem);
                  IoA._Vozrast = Convert.ToString( god);
                  IoA._valyta = Convert.ToString(Valyta.SelectionBoxItem);
                  IoA._dataNachalasroka = Convert.ToDateTime(ld2);
                  IoA._VozrastZastrx = ld4;
                  IoA._dataOkonchaSroka = Convert.ToDateTime(ld);
                  IoA._SrokStr = ld3;
                  IoA._Pereodi = Convert.ToString(Period.SelectionBoxItem);
                  IoA._skidki = Convert.ToString(skidki.SelectionBoxItem);
                  IoA._kyrsVal = kyrs.Text;
                  IoA._kodVznosa = Convert.ToInt32(Nvznosa.Text);
                  IoA.InsertInsuranceOfAdults(IoA._Nstavka, IoA._Vozrast, IoA._pol, IoA._dataNachalasroka, IoA._dataOkonchaSroka, IoA._SrokStr, IoA._VozrastZastrx, IoA._valyta, IoA._Pereodi, IoA._skidki, IoA._kyrsVal, IoA._kodVznosa);
             
              }
              catch(Exception ex)
              {
                  MessageBox.Show("Внесены изменения в таблицу Взносы взрослых" + ex.Message);
              }
              if (Dost_voz.Text != "")
              {
                  string s1;
                  s1 = Dost_voz.Text;
                  Dost_voz.Text = "0";
                  Dost_voz.Text = s1;
              }*/
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

             /*  try
            {
                   ContributionsOfAdults CoA = new ContributionsOfAdults();
                CoA._kodvznos = Convert.ToInt32(Nvznosa.Text);
                CoA._dostVozr = Convert.ToInt32(Dost_voz.Text);
                CoA._smert = Convert.ToInt32(Convert.ToDouble(smert.Text));
                CoA._invalid = Convert.ToInt32(Convert.ToDouble(invalid.Text));
                CoA._vredZdar = Convert.ToInt32(Convert.ToDouble(Vred_zdarov.Text));
                CoA._obVznosPoDostV = Convert.ToInt32(Convert.ToDouble(Ob_vznos.Text));
                    CoA._NesSlsmert =Convert.ToInt32(Convert.ToDouble(smert_in_nec.Text));
        CoA._NesSlinvalid =Convert.ToInt32(Convert.ToDouble(invalid_in_nec.Text));
        CoA._vremenNetryd = Convert.ToInt32(Convert.ToDouble(Vrem_netryd.Text));
        CoA._NesSlvremenNetryd =Convert.ToInt32(Convert.ToDouble(Vrem_netryd_in_nec.Text));
                CoA.UpdateContributionsOfAdults(CoA._dostVozr, CoA._smert, CoA._invalid, CoA._vredZdar, CoA._obVznosPoDostV, CoA._kodvznos,CoA._NesSlsmert,CoA._NesSlinvalid, CoA._vremenNetryd,CoA._NesSlvremenNetryd);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильно внесены данные для обновления" + ex.Message);
            }

               if (Dost_voz.Text != "")
               {
                   string s1;
                   s1 = Dost_voz.Text;
                   Dost_voz.Text = "0";
                   Dost_voz.Text = s1;
               }*/
        }

        private void Button_Click_98(object sender, RoutedEventArgs e)
        {
            /*spisok_vznosov_vzroslix vzros = new spisok_vznosov_vzroslix();
            vzros.Show();*/

        }

        private void Button_Click_YD(object sender, RoutedEventArgs e)
        {
           /* InsuranceOfAdults IoA = new InsuranceOfAdults();
            IoA.DeleteInsuranceOfAdults();*/

        }

        private void Button_Click_YDV(object sender, RoutedEventArgs e)
        {
           /* ContributionsOfAdults CoA = new ContributionsOfAdults();
            CoA.DeleteContributionsOfAdults(Klient2.Nvznosa);*/
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

        private void Dost_voz_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* try
            {
                Klient2.Nvznosa = Convert.ToInt32(Nvznosa.Text);
                if (skidki.SelectionBoxItem.ToString() != "" && Godrag.Text != "" && Period.SelectionBoxItem.ToString() != "" && pol.SelectionBoxItem.ToString() != "" && Valyta.Text != "" && Klient2.Nvznosa != 0)
                {



                    double _ob = 0;
                    double _ob2 = 0;
                    double _ob3 = 0;
                    double _ob4 = 0;
                    double _ob5 = 0;
                    double _ob6 = 0;
                    double _ob7 = 0;
                    double _ob8 = 0;
                    if (Dost_voz.Text != "0")
                    {

                        DataTable inv = new DataTable();
                        string sql = string.Format("Select * From Ставка_взрослых Where Пол='{0}' AND Возраст={1}", pol.Text, Convert.ToInt32(let.Text));
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
                        double fx = Convert.ToDouble(inv.Rows[0][7].ToString());
                        double nx = Convert.ToDouble(inv.Rows[0][8].ToString());
                        double tarif = Math.Round(((lx / (dx + bx) / hx * 2 - 0.2 + 7) * 10), 3);
                        if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                            limit = Convert.ToDouble(Dost_voz.Text);
                        else
                        {
                            limit = Convert.ToDouble(Dost_voz.Text) * Convert.ToDouble(kyrs.Text);
                            kye = limit;
                        }

                        TdosV.Text = tarif.ToString();
                        double limit3 = tarif * limit / 100;
                        double letr = Convert.ToDouble(let.Text);
                        double letr2 = Convert.ToDouble(let2.Text);
                        LdosV.Text = limit3.ToString();
                        tarif = Math.Abs(Math.Round((100 - tarif) / 2 / 10, 3));

                        if (Chsmert.IsChecked == true)
                        {

                            Tsmert.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Lsmert.Text = limi2.ToString();
                            limi2 =Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            smert.Text = limi2.ToString();

                        }

                        if (Chsmert_net.IsChecked == true)
                        {
                            Tsmertotnes.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Lsmertotnes.Text = limi2.ToString();
                            limi2 = Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            smert_in_nec.Text = limi2.ToString();
                        }


                        tarif = Math.Round(tarif / 2, 3);
                        if (Chinvalid.IsChecked == true)
                        {
                            Tinval.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Linval.Text = limi2.ToString();
                            limi2 = Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            invalid.Text = limi2.ToString();
                        }

                        if (Chinval_net.IsChecked == true)
                        {
                            Tinvalid.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Linvalid.Text = limi2.ToString();
                            limi2 = Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            invalid_in_nec.Text = limi2.ToString();
                        }
                        tarif = Math.Round(tarif * zx / hx, 3);
                        if (ChVred_zdarov.IsChecked == true)
                        {

                            Tvredzdar.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Lvredzdar.Text = limi2.ToString();
                            limi2 = Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            Vred_zdarov.Text = limi2.ToString();
                        }
                        tarif = Math.Round(tarif * fx / nx,3);
                        ///Временная нетрудоспособность
                        if (ChVrem_net.IsChecked == true)
                        {

                            Tvremnetry.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Lvremnetry.Text = limi2.ToString();
                            limi2 = Math.Abs( Math.Round(tarif * limit / letr / letr2, 3));
                            Vrem_netryd.Text = limi2.ToString();
                        }
                        if (Chnetot_net.IsChecked == true)
                        {

                            Tvreotnessl.Text = tarif.ToString();
                            double limi2 = tarif * limit / 100;
                            Lvreotnessl.Text = limi2.ToString();
                            limi2 =Math.Abs(  Math.Round(tarif * limit / letr / letr2, 3));
                            Vrem_netryd_in_nec.Text = limi2.ToString();
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
                        if (ChVrem_net.IsChecked == true)
                        {

                            _ob5 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(Vrem_netryd.Text);

                        }
                        if (Chsmert_net.IsChecked == true)
                        {

                            _ob6 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(smert_in_nec.Text);

                        }
                        if (Chinval_net.IsChecked == true)
                        {

                            _ob7 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(invalid_in_nec.Text);

                        }
                        if (Chnetot_net.IsChecked == true)
                        {

                            _ob8 = Convert.ToDouble(Dost_voz.Text) + Convert.ToDouble(Vrem_netryd_in_nec.Text);

                        }
                        if (ChVred_zdarov.IsChecked == false && Chinvalid.IsChecked == false && Chsmert.IsChecked == false)
                            Ob_vznos.Text = Dost_voz.Text;
                        //  _ob = _ob2 + Convert.ToDouble(Dost_voz.Text);
                        // Ob_vznos.Text = _ob.ToString();
                        _ob = _ob2 + _ob3 + _ob4 + _ob5 + _ob6 + _ob7 + _ob8 + Convert.ToDouble(Dost_voz.Text);
                        if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                            OBrVz.Text = _ob.ToString();
                        else
                        {
                            _ob = _ob * kye;
                            OBrVz.Text = _ob.ToString();
                        }
                        if (Period.SelectionBoxItem.ToString() == "единовременно")
                            OBVpoDO.Text = _ob.ToString();
                        else if (Period.SelectionBoxItem.ToString() == "ежегодно")
                        {
                            _ob = _ob * 5;

                            OBVpoDO.Text = _ob.ToString();
                        }
                        else if (Period.SelectionBoxItem.ToString() == "ежеквартально")
                        {
                            _ob = _ob * 20;
                            OBVpoDO.Text = _ob.ToString();
                        }
                        else if (Period.SelectionBoxItem.ToString() == "ежемесячно")
                        {
                            _ob = _ob * 60;
                            OBVpoDO.Text = _ob.ToString();
                        }
                        if (skidki.SelectionBoxItem.ToString() == "4_2")
                        {
                            _ob = Convert.ToDouble(OBVpoDO.Text) + 8;
                            STRsumma.Text = _ob.ToString();
                        }
                        else if (skidki.SelectionBoxItem.ToString() == "4_4")
                        {
                            _ob = Convert.ToDouble(OBVpoDO.Text) + 16;
                            STRsumma.Text = _ob.ToString();
                        }
                        else if (skidki.SelectionBoxItem.ToString() == "4_6")
                        {
                            _ob = Convert.ToDouble(OBVpoDO.Text) + 24;
                            STRsumma.Text = _ob.ToString();
                        }
                        else if (skidki.SelectionBoxItem.ToString() == "нет")
                        {

                            STRsumma.Text = OBVpoDO.Text;
                        }


                        double nalog;
                        int round_val = 0;
                        if (Convert.ToString(Valyta.SelectionBoxItem) == "Иностранная валюта")
                            round_val = 2;
                        else
                            round_val = 0;
                        nalog = Math.Round(Convert.ToDouble(OBVpoDO.Text) * 0.12, round_val);
                        Nalogv.Text = nalog.ToString();

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
                        progBonys.Text = Bonus.ToString();

                    }



                }
            }
            catch
            {
                MessageBox.Show("Неправильно внесены данные");
            }*/
        }

        private void Button_Click_raschet(object sender, RoutedEventArgs e)
        {
          /*  spisok_raschetov_vzrosl ras = new spisok_raschetov_vzrosl();
            ras.Show();

            this.Close();*/
        }

     

        private void ClickBlank5(object sender, RoutedEventArgs e)
        {
            Process.Start(@"E:\PROG2\WPF\9781430243656\ProProjectVER_2\ProProjectVER_1\Assets\Договор ФЛ Пр № 6.doc");
        }

      
    
            }
    }

