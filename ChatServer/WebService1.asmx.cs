using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public bool SendMessage(string who, string message)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //ListOfRicievers Ricievers = new ListOfRicievers();
            //string[] list = Ricievers.Get("");

            SqlConnectionHlp objectConnection = null; // lokalni promenne jsou malymi pismeny

            try
            {
                objectConnection = new SqlConnectionHlp();
                //for (int i = 0; i < list.Length; i++)
                //tady by se daly vyuzit SQLParameters          
                objectConnection.DoCommand(String.Format("INSERT INTO Messages ([From],Message,DateTime) VALUES ('{0}','{1}','{2}')", who, message,DateTime.Now));
            }
            catch (Exception e)
            {
                // zalogovat exception log4net                
                throw;                   // a jelikoz nevime co s ni posleme ji dal; dej pozor na rozdil mezi "throw" a "throw e"
            }            
            finally                                 // tento block se vykona za kazde situace
            {
                if(objectConnection!=null)          // musime overit jestli neni objectConnection null jinak nasledujic radek vyhodi vyjimku
                    objectConnection.Close();       // pouzivej formatovani pomoci odsazovani tabem, na jen radek jen prikaz!!!
            }
            return true;
        }

        [WebMethod]
        public List<OneMessage> Refresh()
        {
            SqlConnectionHlp objectConnection = null;
            List<OneMessage> messages = null;
            try
            {
                objectConnection = new SqlConnectionHlp();

                SqlDataReader Reader = objectConnection.DoCommand(@"SELECT * FROM Messages");

                messages = new List<OneMessage>();
                OneMessage m;
                while (Reader.Read())
                {
                    m.From = (string)Reader["From"];
                    m.Message = (string)Reader["Message"];
                    m.DateTime = (DateTime)Reader["DateTime"];
                    messages.Add(m);
                }                
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (objectConnection != null)
                    objectConnection.Close();
            }
                                   
            return messages;    
        }
    }
}
