using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace kursachV1.Classes
{
    public class WageOfTheStatistician:IAge
    {
        public int _variant { get; set; }
        public int _life { get; set; }
        public int _alldead { get; set; }
        public int _DTP { get; set; }
        public int _NS { get; set; }
        public int _ES { get; set; }
        public int _vozrast { get; set; }
        public string _pol { get; set; }

        public DateTime _data { get; set; }
        SqlConnection sc;
        public void UpdateInsuranseStatistac(int variant,string pol,int lx, int dx, int bx, int zx, int fx, int document, DateTime data)
        {
            SqlDataAdapter da;
            DataSet ds;
            sc = new SqlConnection(kursachV1.Properties.Settings.Default.krutV2ConnectionString);
            sc.Open();
            string query2 = string.Format("Update Ставка_статистика  Set Дожившие={0},Всего_умерших={1},ДТП_за_5_лет={2},Несчастные_случаи_за_5_лет={3},Естественные_причины_за_5_лет={4},Дата_внесения_записей=Convert(datetime,'{5}',103) Where Вариант_страхования= '{6}' AND Возраст= '{7}' AND Пол= '{8}' ", lx, dx, bx, zx, fx, data, variant, document, pol);
            da = new SqlDataAdapter(query2, sc);
            ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Внесены изменения в таблицу ставки статистики");
        }
        public void DeleteInsuranseStatistac(int variant, int document, string pol)
        {
            sc = new SqlConnection(kursachV1.Properties.Settings.Default.krutV2ConnectionString);
            sc.Open();
            string sql = string.Format("Delete from Ставка_статистика where Вариант_страхования= '{0}' AND Возраст= '{1}' AND Пол= '{2}'", variant,document,pol);
            using (SqlCommand cmd = new SqlCommand(sql, this.sc))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("К сожалению, ставка статистики связана!", ex);
                    MessageBox.Show(error.Message);
                }
            }
            MessageBox.Show("Внесены изменения в таблицу ставки статистики");
        }
    }
}
