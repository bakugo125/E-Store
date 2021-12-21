using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OnlineStore.Common
{
    public class Connection
    {
        public string connectionString()
        {
            string connString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ConnectionString;
            return connString;
        }

        public static string getConnectionString()
        {
            string connString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ConnectionString;
            return connString;
        }

    }
}