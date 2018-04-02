using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITSUP2018.Class
{
    public static class ConnectionDB
    {
        private static SqlConnection conn;
        static ConnectionDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ToString();
            conn = new SqlConnection(connectionString);
        }

        public static SqlConnection GetSqlConnection()
        {
            return conn;
        }

    }
}