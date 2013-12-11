using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class ListOfRicievers
    {
        public ListOfRicievers()
        { }

        private string[] list; // tahle promena kdyz byla jako lokalni uvnitr Get, neslo do ni prirayovat list[i++] = (string) Reader["Nick"]

        public string[] Get(string who)
        {
            SqlConnectionHlp ObjectConnection = new SqlConnectionHlp();
            SqlDataReader Reader = ObjectConnection.DoCommand("SELECT \"Nick\" FROM Users");
            
            int i = 0;
            while (Reader.Read())
                list[i++] = (string) Reader["Nick"]; // toto hlasilo chybu kdyz list byl deklarovany v aktualnim oboru

            ObjectConnection.Close();
            return list;
        }
    }
}