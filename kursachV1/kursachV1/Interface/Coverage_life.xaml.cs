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
    /// Логика взаимодействия для Straxov_gizni.xaml
    /// </summary>
    public partial class Coverage_life : Window
    {
        SqlConnection sc;
  
        string[] installs = new string[] { "3", "4", "5", "6", "7", "8", "9", "10" };
        string[] installs2 = new string[] { "Мужчины", "Женщины" };
        public Coverage_life()
        {
            InitializeComponent();
            if (Sotryd._count == 2)
            {

                Straxov_vznos.IsEnabled = false;

            }
             foreach (string i in installs)
                 Godrag.Items.Add(i);
             Godrag.SelectedIndex = 0;
            foreach (string i in installs2)
                pol.Items.Add(i);
            sc = new SqlConnection(Sotryd.myConnectionString);
           // sc = new SqlConnection(@"Data Source=PC-Maverick;Initial Catalog=Pro100;Integrated Security=True");
            sc.Open();
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

        public spisok_rechetov_gizni spisok_rechetov_gizni
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            foreach (string j in installs2)
                if (j == Klient2.Kpol)
                    pol.SelectedItem = j;
            Ndog2.Content = Klient2.Ndogovor.ToString();
            if (Klient2.year != 0 && Klient2.year != 1)
            {
                int let2 = d1.Year - Klient2.year;
                let.Text = Convert.ToString(let2);
            }
            Godrag.SelectedIndex = 0;


            if (Ndog2.Content.ToString() != "0")
            {
                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Обслуж_Страхование_жизни Where Номер_договора={0}", Klient2.Ndogovor);
                using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    inv.Load(dr);
                    dr.Close();
                }
                if (inv.Rows.Count != 0)
                {
                    Valyta.Text = inv.Rows[0][0].ToString();
                    Godrag.Text = inv.Rows[0][1].ToString();
                    Period.Text = inv.Rows[0][3].ToString();
                    Kyrs_val.Text = inv.Rows[0][7].ToString();
                    Nstavka.Text = inv.Rows[0][8].ToString();
                    let.Text = inv.Rows[0][9].ToString();
                    pol.Text = inv.Rows[0][10].ToString();
                    NormaDox.Text = inv.Rows[0][13].ToString();
                    Nagryzka.Text = inv.Rows[0][14].ToString();
                    KolVznos.Text = inv.Rows[0][12].ToString();
                    Straxov_vznos.Text = inv.Rows[0][2].ToString();
           
                }
           
           
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
            DateTime d1 = DateTime.Now;
            int let2 = d1.Year - Klient2.year;
            let.Text = Convert.ToString(let2);

            foreach (string j in installs2)
                if (j == Klient2.Kpol)
                    pol.SelectedItem = j;

            Ndog2.Content = Klient2.Ndogovor.ToString();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                LifeInsurance life = new LifeInsurance();
                life._Valyta = Convert.ToString(Valyta.SelectionBoxItem);
                life._srok_str = Convert.ToInt32(Godrag.SelectionBoxItem);
                life._srok_vz = Convert.ToInt32(Straxov_vznos.Text);
                life._PeriodiYplati = Convert.ToString(Period.SelectionBoxItem);
                life._summastrVz = Convert.ToInt32(Symma_str_vznosa.Text);
                life._progBonys = Convert.ToDouble(Bonys.Text);
                life._Nalogvichat = Convert.ToInt32(Nalog_vichat.Text);
                life._KyrsValyt = Convert.ToInt32(Kyrs_val.Text);
                life._Nstavki = Convert.ToInt32(Nstavka.Text);
                life._Vozrast = Convert.ToInt32(let.Text);
                life._Pol = Convert.ToString(pol.SelectionBoxItem);
                life._KolVz = Convert.ToInt32(KolVznos.Text);
                life._NormaDox = Convert.ToInt32(NormaDox.Text);
                life._Nagryz = Convert.ToInt32(Nagryzka.Text);
                life.UpdateLife(life._srok_str, life._Valyta, life._srok_vz, life._PeriodiYplati, life._summastrVz, life._progBonys, life._Nalogvichat, life._KyrsValyt, life._Nstavki, life._Vozrast, life._Pol, life._KolVz, life._NormaDox, life._Nagryz);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                LifeInsurance life = new LifeInsurance();
                life._Valyta = Convert.ToString(Valyta.SelectionBoxItem);
                life._srok_str = Convert.ToInt32(Godrag.SelectionBoxItem);
                life._srok_vz = Convert.ToInt32(Straxov_vznos.Text);
                life._PeriodiYplati = Convert.ToString(Period.SelectionBoxItem);
                life._summastrVz = Convert.ToInt32(Symma_str_vznosa.Text);
                life._progBonys = Convert.ToDouble(Bonys.Text);
                life._Nalogvichat = Convert.ToInt32(Nalog_vichat.Text);
                life._KyrsValyt = Convert.ToInt32(Kyrs_val.Text);
                life._Nstavki = Convert.ToInt32(Nstavka.Text);
                life._Vozrast = Convert.ToInt32(let.Text);
                life._Pol = Convert.ToString(pol.SelectionBoxItem);
                life._KolVz = Convert.ToInt32(KolVznos.Text);
                life._NormaDox = Convert.ToInt32(NormaDox.Text);
                life._Nagryz = Convert.ToInt32(Nagryzka.Text);
                life.InsertLife(life._srok_str, life._Valyta, life._srok_vz, life._PeriodiYplati, life._summastrVz, life._progBonys, life._Nalogvichat, life._KyrsValyt, life._Nstavki, life._Vozrast, life._Pol, life._KolVz, life._NormaDox, life._Nagryz);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextChanged_12(object sender, TextChangedEventArgs e)
        {

            if (Straxov_vznos.Text != "" && Godrag.SelectionBoxItem.ToString() != "" && Period.SelectionBoxItem.ToString() != "" && pol.SelectionBoxItem.ToString() != "" && Valyta.Text != "")
            {
    double suma;
    if (KolVznos.Text != "")
    {
        suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text);
        Symma_str_vznosa.Text = suma.ToString();
    }

    double ставка, показатель;
    int round_val;
    DataTable inv = new DataTable();
    string sql = string.Format("Select * From Ставка Where Номер_ставки={0}", 1);
        using (SqlCommand cmd = new SqlCommand(sql, this.sc))
        {
            SqlDataReader dr = cmd.ExecuteReader();
            inv.Load(dr);
            dr.Close();
        }

    if (Convert.ToString(Valyta.SelectionBoxItem) == "Иностранная валюта")
    {
        round_val = 2;
        ставка = Convert.ToDouble( inv.Rows[0][3])/100;
        показатель = Convert.ToDouble(inv.Rows[0][1]) / 100;
    }
    else{
    round_val = 0;
    ставка = Convert.ToDouble(inv.Rows[0][2]) / 100;
    показатель = Convert.ToDouble(inv.Rows[0][0]) / 100;
    }
    double норма_доходности = Convert.ToInt32(NormaDox.Text) / 100;
      double Bonus=0;
          double KolVzno =Convert.ToInt32( KolVznos.Text);
            double kelre = Convert.ToInt32(Straxov_vznos.Text);
             double nagryz = Convert.ToInt32(Nagryzka.Text)/100;
             double NormaDox2 = Convert.ToInt32(NormaDox.Text) / 100;

            if ((ставка * показатель - норма_доходности) < 0)
                Bonus = 0;
            else
                for (int y=1; y < KolVzno; y++)
                    Bonus = Bonus + kelre * (1 - nagryz) * (ставка * показатель - NormaDox2) * y * 1 / KolVzno;
            Bonys.Text = Bonus.ToString();
            if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
            {
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100;
                    suma = suma + suma * 0.02;
                }
                dogid_01_01.Text = suma.ToString();
                dtp_01_01.Text = suma.ToString();
                smerti_01_01.Text = suma.ToString();
                smertie_01_01.Text = suma.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 2;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 2;
                    suma = suma + suma * 0.02;
                }
                dogid_01_02.Text = suma.ToString();
                dtp_01_02.Text = suma.ToString();
                smerti_01_02.Text = suma.ToString();
                smertie_01_02.Text = suma.ToString();
                double suma2=0;
                double suma3 = 0;
                double suma4 = 0;
                suma2 = suma;
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_02.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_02.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_02.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                    suma = suma + suma * 0.02;
                }
                dogid_01_03.Text = suma.ToString();
                suma2 = Convert.ToInt32(Straxov_vznos.Text) * 10 + Convert.ToInt32(Straxov_vznos.Text) * 10 * Convert.ToInt32(NormaDox.Text) / 100;
                smerti_01_03.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_03.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_03.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_03.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                    suma = suma + suma * 0.02;
                }
                dogid_01_04.Text = suma.ToString();
                suma2 = suma * 2;
                dtp_01_04.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_04.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_04.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_04.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 6;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 6;
                    suma = suma + suma * 0.02;
                }
                dogid_01_05.Text = suma.ToString();
                suma2 = suma * 2;
                dtp_01_05.Text = suma2.ToString();
                suma2 = Convert.ToInt32(Straxov_vznos.Text) * 10 + Convert.ToInt32(Straxov_vznos.Text) * 10 * Convert.ToInt32(NormaDox.Text) / 100;
                smerti_01_05.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_05.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_05.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_05.Text = suma4.ToString();
                double tar;
                double tar2;
                tar = Convert.ToInt32(let.Text) * Convert.ToInt32(KolVznos.Text)* Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(NormaDox.Text) * Convert.ToInt32(Nagryzka.Text)/100/100 ;
                tarif_01_03.Text = tar.ToString();
                tar2 = tar + 1;
                tarif_01_01.Text = tar2.ToString();
                tar2 = tar + 0.9723;
                tarif_01_02.Text = tar2.ToString();
                tar2 = tar - tar * Convert.ToInt32(Nagryzka.Text)*2 / 100;
                tarif_01_04.Text = tar2.ToString();
                tar2 = tar - tar * Convert.ToInt32(Nagryzka.Text)  / 100;
                tarif_01_05.Text = tar2.ToString();
            }
            else if (Valyta.SelectionBoxItem.ToString() == "Иностранная валюта")
            {
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100;
                    suma = suma + suma * 0.02;
                }
                dogid_01_01.Text = suma.ToString();
                dtp_01_01.Text = suma.ToString();
                smerti_01_01.Text = suma.ToString();
                smertie_01_01.Text = suma.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 2;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 2;
                    suma = suma + suma * 0.02;
                }
                dogid_01_02.Text = suma.ToString();
                dogid_01_02.Text = suma.ToString();
                dtp_01_02.Text = suma.ToString();
                smerti_01_02.Text = suma.ToString();
                smertie_01_02.Text = suma.ToString();
                double suma2 = 0;
                double suma3 = 0;
                double suma4 = 0;
                suma2 = suma;
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_02.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_02.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_02.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                    suma = suma + suma * 0.02;
                }
                dogid_01_03.Text = suma.ToString();
                dogid_01_03.Text = suma.ToString();
                suma2 = Convert.ToInt32(Straxov_vznos.Text) * 10 + Convert.ToInt32(Straxov_vznos.Text) * 10 * Convert.ToInt32(NormaDox.Text) / 100;
                smerti_01_03.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_03.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_03.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_03.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 4;
                    suma = suma + suma * 0.02;
                }
                dogid_01_04.Text = suma.ToString();
                dogid_01_04.Text = suma.ToString();
                suma2 = suma * 2;
                dtp_01_04.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_04.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_04.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_04.Text = suma4.ToString();
                if (Valyta.SelectionBoxItem.ToString() == "Мужчины")
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 6;
                else
                {
                    suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text) * Convert.ToInt32(Kyrs_val.Text) * Convert.ToInt32(Nagryzka.Text) / 100 * 2 - Convert.ToInt32(let.Text) * Convert.ToInt32(NormaDox.Text) / 100 * 6;
                    suma = suma + suma * 0.02;
                }
                dogid_01_05.Text = suma.ToString();

                suma2 = suma * 2;
                dtp_01_05.Text = suma2.ToString();
                suma2 = Convert.ToInt32(Straxov_vznos.Text) * 10 + Convert.ToInt32(Straxov_vznos.Text) * 10 * Convert.ToInt32(NormaDox.Text) / 100;
                smerti_01_05.Text = suma2.ToString();
                suma2 = suma / 2 + Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv1_01_05.Text = suma2.ToString();
                suma3 = suma / 2;
                inv2_01_05.Text = suma3.ToString();
                suma4 = suma / 2 - Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem);
                inv3_01_05.Text = suma4.ToString();





                double tar;
                double tar2;
                tar = Convert.ToInt32(let.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(NormaDox.Text) / 100 * Convert.ToInt32(Nagryzka.Text) / 100 * 12;
                tarif_01_03.Text = tar.ToString();
                tar2 = tar + 1;
                tarif_01_01.Text = tar2.ToString();
                tar2 = tar + 0.9723;
                tarif_01_02.Text = tar2.ToString();
                tar2 = tar - tar * Convert.ToInt32(Nagryzka.Text) * 2 / 100;
                tarif_01_04.Text = tar2.ToString();
                tar2 = tar - tar * Convert.ToInt32(Nagryzka.Text) / 100;
                tarif_01_05.Text = tar2.ToString();
            }
            }
        }

        private void TextChacheg_13(object sender, TextChangedEventArgs e)
        {
            double suma;
            if (Straxov_vznos.Text != "")
            {
                suma = Convert.ToInt32(Straxov_vznos.Text) * Convert.ToInt32(Godrag.SelectionBoxItem) * Convert.ToInt32(KolVznos.Text);
                Symma_str_vznosa.Text = suma.ToString();
            }
        }

        private void Text_changed34(object sender, TextChangedEventArgs e)
        {
            double nalog;
            int round_val = 0;
            if(Convert.ToString(Valyta.SelectionBoxItem) =="Иностранная валюта")
                 round_val = 2;
            else
               round_val = 0;
            nalog = Math.Round(Convert.ToInt32(Symma_str_vznosa.Text)*0.12, round_val);
            Nalog_vichat.Text = nalog.ToString();

        }

        private void Button_Click_YD(object sender, RoutedEventArgs e)
        {
            LifeInsurance life = new LifeInsurance();
            life.DeleteLife();
        }

        private void Period_DropDownClosed(object sender, EventArgs e)
        {
            if (Period.SelectionBoxItem.ToString() == "ежемесячно")
                KolVznos.Text = "12";
            else if (Period.SelectionBoxItem.ToString() == "ежегодно")
                KolVznos.Text = "1";
            else if (Period.SelectionBoxItem.ToString() == "единовременно")
                KolVznos.Text = "0";
        }

        private void Valyta_DropDownClosed(object sender, EventArgs e)
        {
            if (Valyta.SelectionBoxItem.ToString() == "Белорусские рубли")
                Kyrs_val.IsEnabled = false;
            else
                Kyrs_val.IsEnabled = true;
            if (Straxov_vznos.Text != "")
            {
                string s1;
                s1 = Straxov_vznos.Text;
                Straxov_vznos.Text = "0";
                Straxov_vznos.Text = s1;
            }
        }

        private void Kyrs_val_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Straxov_vznos.Text != "")
            {
                string s1;
                s1 = Straxov_vznos.Text;
                Straxov_vznos.Text = "0";
                Straxov_vznos.Text = s1;
            }
        }

        private void Nagryzka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Straxov_vznos.Text != "")
            {
                string s1;
                s1 = Straxov_vznos.Text;
                Straxov_vznos.Text = "0";
                Straxov_vznos.Text = s1;
            }
        }

        private void NormaDox_TextChanged(object sender, TextChangedEventArgs e)
        {
              if (Straxov_vznos.Text != "")
            {
                string s1;
                s1 = Straxov_vznos.Text;
                Straxov_vznos.Text = "0";
                Straxov_vznos.Text = s1;
            }
        }

        private void pol_DropDownClosed(object sender, EventArgs e)
        {
            if (Straxov_vznos.Text != "")
            {
                string s1;
                s1 = Straxov_vznos.Text;
                Straxov_vznos.Text = "0";
                Straxov_vznos.Text = s1;
            }
        }

        private void Button_Click_OBR(object sender, RoutedEventArgs e)
        {
            spisok_rechetov_gizni ras = new spisok_rechetov_gizni();
            ras.Show();
            this.Close();
        }

        private void Clickdogovor(object sender, RoutedEventArgs e)
        {
            Process.Start(@"E:\PROG2\WPF\9781430243656\ProProjectVER_2\ProProjectVER_1\Assets\Прилож 1. Договор ФЛ Пр № 1.doc");
        }

  




    

   

   

  

     
    }
}
