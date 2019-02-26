using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDWesley
{
    public class Conexao
    {
        public SqlConnection ConectarSql(ref SqlConnection con)
        {
            if (con != null)
            {
                con.Dispose();
            }
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return con;
        }
    }

}