using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CSJM.Models
{
    public class ConnectionManager
    {
        SqlConnection con = new SqlConnection(@"Data Source=PARVEZ-PC\SQLEXPRESS;Initial Catalog=GPAurai;Integrated Security=True");
        public bool ExecuteInsertUpdateOrDelete(string command)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetBulkRecord(string command)
        {
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}