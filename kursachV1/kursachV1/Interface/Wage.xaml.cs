using kursachV1.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace kursachV1.Interface
{
    /// <summary>
    /// Interaction logic for Wage.xaml
    /// </summary>
    public partial class Wage : Window
    {
        KrutDataSetTableAdapters.СтавкаTableAdapter adapter;
        KrutDataSet dataset = new KrutDataSet();
        SqlConnection sc;

        public Wage()
        {
            InitializeComponent();
            adapter = new KrutDataSetTableAdapters.СтавкаTableAdapter();
            adapter.Fill(dataset.Ставка);
            this.DataContext = dataset.Ставка.DefaultView;
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
                    var query = "Select Номер_ставки From Ставка";
                    SqlDataAdapter da = new SqlDataAdapter(query, sc);
                    da.Fill(dt);
                    string str = dt.DefaultView[DataGri2d.SelectedIndex]["Номер_ставки"].ToString();
                    spisr = str;
                }
                DataTable inv = new DataTable();
                string sql = string.Format("Select * From Ставка Where Номер_ставки={0}", Convert.ToInt32(spisr));


                using (SqlCommand cmd = new SqlCommand(sql, this.sc))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    inv.Load(dr);
                    dr.Close();
                }
                StaticClass.Nstavki = Convert.ToInt32(inv.Rows[0][0].ToString());
                document.Text = inv.Rows[0][0].ToString();
                lx.Text = inv.Rows[0][2].ToString();
                dx.Text = inv.Rows[0][3].ToString();
                pokaz.Text = inv.Rows[0][1].ToString();
                pokazat2.Text = inv.Rows[0][4].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильно выбраны данные!" + ex.Message);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            CommonWage commonWage = new CommonWage();
            commonWage._PoY = Convert.ToInt32(pokaz.Text);
            commonWage._PoYinv = Convert.ToInt32(lx.Text);
            commonWage._ProgSrefen = Convert.ToInt32(dx.Text);
            commonWage._srProSt = Convert.ToDouble(pokazat2.Text);
            commonWage.UpdateWage(commonWage._PoY, commonWage._PoYinv, commonWage._ProgSrefen, commonWage._srProSt);
            adapter = new KrutDataSetTableAdapters.СтавкаTableAdapter();
            adapter.Fill(dataset.Ставка);
            this.DataContext = dataset.Ставка.DefaultView;
            MessageBox.Show("Внесены изменения в таблицу ставки");
        }
    }
}
