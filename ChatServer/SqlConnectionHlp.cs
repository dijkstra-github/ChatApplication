using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;


namespace WebApplication2
{
    public class SqlConnectionHlp
    {
        public SqlConnectionHlp()
        {
            string cn = ConfigurationManager.AppSettings["ConnectionString"];
            ObjectConnection = new SqlConnection(cn);
        }

        public SqlConnectionHlp(string ConnectionString)
        {
            ObjectConnection = new SqlConnection(ConnectionString);
        }

        private SqlConnection ObjectConnection;

        public SqlDataReader DoCommand(string command)
        {
            ObjectConnection.Open();
            SqlCommand ObjectCommand = new SqlCommand(command, ObjectConnection);
            if (command.Contains("SELECT"))            
                return ObjectCommand.ExecuteReader();            
            else
            {
                ObjectCommand.ExecuteNonQuery();
                return null;
            }
        }

        public void Close()
        {
            ObjectConnection.Close();
        }

    }
}