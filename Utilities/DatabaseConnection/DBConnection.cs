using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Utilities.DatabaseConnection
{
    public class DBConnection
    {
        static string connectionString = "Server=DESKTOP-J347NL0\\SQLEXPRESS;Database=GEDRH; User Id=root;Password=; Trusted_Connection=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cn;
        }
    }
}
