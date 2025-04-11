using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DataProvider
    {
        private SqlConnection cn;

        public DataProvider() 
        {
            string snStr = "Data Source=LAPTOP-3RVB0QLD;Initial Catalog=BloodBank;Integrated Security=True";
            cn = new SqlConnection(snStr);
        }



        private void Connect()
        {
            try
            {
                //phải có using System.Data mới dùng được ConnectionState
                if(cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }    
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }


        private void DisConnect()
        {
            if(cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }    
        }


        public object MyExecuteScalar(string sql,CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            Connect();

            try
            {
                return (cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
