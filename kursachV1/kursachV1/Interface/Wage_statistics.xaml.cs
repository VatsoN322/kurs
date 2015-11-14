using kursachV1.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace kursachV1.Interface
{
    /// <summary>
    /// Interaction logic for Wage_statistics.xaml
    /// </summary>
    public partial class Wage_statistics : Window
    {
        KrutDataSetTableAdapters.Ставка_статистикаTableAdapter adapter;
        KrutDataSet dataset = new KrutDataSet();
        SqlConnection sc;
        public Wage_statistics()
        {
            InitializeComponent();
            adapter = new KrutDataSetTableAdapters.Ставка_статистикаTableAdapter();
            adapter.Fill(dataset.Ставка_статистика);

            dataset.Ставка_статистика.Ставка_статистикаRowChanged += new KrutDataSet.Ставка_статистикаRowChangeEventHandler(Ставка_статистикаRowModified);
            this.DataContext = dataset.Ставка_статистика.DefaultView;
        }
        void Ставка_статистикаRowModified(object sender, KrutDataSet.Ставка_статистикаRowChangeEvent e)
        {
            adapter.Update(dataset.Ставка_статистика);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var spisr = "";
                if (DataGri2d.SelectedItem != null)
                {
                    sc = new SqlConnection(kursachV1.Properties.Settings.Default.krutV2ConnectionString);

                    sc.Open();
                    DataTable dt = new DataTable();
                    var query = "Select Вариант_страхования From Ставка_статистика";
                    SqlDataAdapter da = new SqlDataAdapter(query, sc);
                    da.Fill(dt);
                    string str = dt.DefaultView[DataGri2d.SelectedIndex]["Вариант_страхования"].ToString();
                    spisr = str;
                }
                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Ставка_статистика Where Вариант_страхования='{0}'", spisr);


                using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    inv.Load(dr);
                    dr.Close();
                }
                StaticClass.Nstavst = Convert.ToInt32(inv.Rows[0][0].ToString());
                document.Text = inv.Rows[0][1].ToString();
                vCoverage.Text = inv.Rows[0][0].ToString();
                pol.Text = inv.Rows[0][2].ToString();
                lx.Text = inv.Rows[0][3].ToString();
                dx.Text = inv.Rows[0][4].ToString();
                bx.Text = inv.Rows[0][5].ToString();
                zx.Text = inv.Rows[0][6].ToString();
                fx.Text = inv.Rows[0][7].ToString();
                data.Text  = inv.Rows[0][8].ToString();  


            }
            catch (Exception ex)
            { MessageBox.Show("Неправильно выбраны данные" + ex.Message); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WageOfTheStatistician WoTs = new WageOfTheStatistician();
            WoTs._variant = Convert.ToInt32(vCoverage.Text);
            WoTs._vozrast = Convert.ToInt32(document.Text);
            WoTs._pol = pol.Text;
            WoTs.DeleteInsuranseStatistac(WoTs._variant, WoTs._vozrast, WoTs._pol);
            vCoverage.Text = "0";
            document.Text = "0";
            lx.Text = "0";
            dx.Text = "0";
            bx.Text = "0";
            zx.Text = "0";
            fx.Text = "0";
            KrutDataSetTableAdapters.Ставка_статистикаTableAdapter adapter2;
            KrutDataSet dataset2 = new KrutDataSet();
            adapter2 = new KrutDataSetTableAdapters.Ставка_статистикаTableAdapter();
            adapter2.Fill(dataset2.Ставка_статистика);

            dataset2.Ставка_статистика.Ставка_статистикаRowChanged += new KrutDataSet.Ставка_статистикаRowChangeEventHandler(Ставка_статистикаRowModified);
            this.DataContext = dataset2.Ставка_статистика.DefaultView;
        }

        private void Button_Click_Naiti2(object sender, RoutedEventArgs e)
        {
            KrutDataSetTableAdapters.Выбрать_ставку_статистикуTableAdapter adapter2;
            adapter2 = new KrutDataSetTableAdapters.Выбрать_ставку_статистикуTableAdapter();
            adapter2.Fill(dataset.Выбрать_ставку_статистику, pol2.Text, Convert.ToInt32(vozrast2.Text));
            this.DataContext = dataset.Выбрать_ставку_статистику.DefaultView;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            WageOfTheStatistician WoTs = new WageOfTheStatistician();
            WoTs._variant = Convert.ToInt32(vCoverage.Text);
            WoTs._vozrast = Convert.ToInt32(document.Text);
            WoTs._pol = pol.Text;
            WoTs._life = Convert.ToInt32(lx.Text);
            WoTs._alldead = Convert.ToInt32(dx.Text);
            WoTs._DTP = Convert.ToInt32(bx.Text);
            WoTs._NS = Convert.ToInt32(zx.Text);
            WoTs._ES = Convert.ToInt32(fx.Text);
            WoTs._data = DateTime.Now;
            WoTs.UpdateInsuranseStatistac(WoTs._variant,WoTs._pol, WoTs._life, WoTs._alldead, WoTs._DTP, WoTs._NS, WoTs._ES, WoTs._vozrast, WoTs._data);

            KrutDataSetTableAdapters.Ставка_статистикаTableAdapter adapter2;
            KrutDataSet dataset2 = new KrutDataSet();
            adapter2 = new KrutDataSetTableAdapters.Ставка_статистикаTableAdapter();
            adapter2.Fill(dataset2.Ставка_статистика);

            dataset2.Ставка_статистика.Ставка_статистикаRowChanged += new KrutDataSet.Ставка_статистикаRowChangeEventHandler(Ставка_статистикаRowModified);
            this.DataContext = dataset2.Ставка_статистика.DefaultView;
        }

        private void DatePicker_DateValidationError(object sender, System.Windows.Controls.DatePickerDateValidationErrorEventArgs e)
        {

        }
    }
}
