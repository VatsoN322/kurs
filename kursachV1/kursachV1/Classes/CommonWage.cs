using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursachV1.Classes
{
    public class CommonWage
    {
        public int _nomerS { get; set; }
        public int _PoY { get; set; }
        public int _PoYinv { get; set; }
        public int _ProgSrefen { get; set; }
        public double _srProSt { get; set; }
        public bool UpdateWage(int Nst, int po, int l, double d)
        {
            bool flag = false;
            string CONNECTION_STRING = kursachV1.Properties.Settings.Default.krutV2ConnectionString;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand com = new SqlCommand("Обновление_общей_ставки", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@pok1";
                param.Value = Nst;
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Direction = System.Data.ParameterDirection.Input;
                com.Parameters.Add(param);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@pok2";
                param2.Value = po;
                param2.SqlDbType = System.Data.SqlDbType.Int;
                param2.Direction = System.Data.ParameterDirection.Input;
                com.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@pr";
                param3.Value = l;
                param3.SqlDbType = System.Data.SqlDbType.Int;
                param3.Direction = System.Data.ParameterDirection.Input;
                com.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@sr";
                param4.Value = d;
                param4.SqlDbType = System.Data.SqlDbType.Float;
                param4.Direction = System.Data.ParameterDirection.Input;
                com.Parameters.Add(param4);

                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1)
                        flag = true;
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
