using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class ChatCommand
    {
        private string command;
        private User who;

        public ChatCommand(User who, string command)
        {
            this.command = command.Remove(0, 1);
            this.who = who;
        }


        public ResultOfOperation Refresh()
        {
            //throw new NotImplementedException();
            ChatService.WebService1SoapClient serviceClient = new ChatService.WebService1SoapClient();

            ChatService.OneMessage[] result = serviceClient.Refresh();
            //object[] result = ServiceReference1.Invoke("Refresh", new object[] {who.nick});
            //List<OneMessage> list = (List<OneMessage>)result[0];
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine("{0}: {1}", result[i].From, result[i].Message);

            return new ResultOfOperation();
        }


        public ResultOfOperation End()
        {
            ResultOfOperation result = new ResultOfOperation();
            result.end_command_indicator = true;
            return result;
        }


        public ResultOfOperation Execute()
        {
            if (command.Contains("refresh")) return Refresh();
            if (command.Contains("End")) return End();
            return new ResultOfOperation();
        }







        /*public ResultOfOperation Connect_chat(User user)
        {
            if (!user.on_line) {
                Console.Write("Nick_name> ");
                string nick = Console.ReadLine();
                Console.Write("Password> ");
                string password = Console.ReadLine();
                object[] results = proxy.Invoke("Connect_chat", new object[] {nick, password});
                if ((bool) results[0])  { user.on_line = true; user.nick = nick; user.password = password; 
                    return new ResultOfOperation(true, "Přihlášení OK");
                }
                else { return new ResultOfOperation(false, "Přihlášení se nezdařilo"); }
            }
            else return new ResultOfOperation(false, "Již jste přihlášen");
        }
    



         public ResultOfOperation Disconnect_chat(User user)
         {
             if (user.on_line) {
                 proxy.Invoke("Disconnect_chat", new object[] {user.nick, user.password});
                 user.on_line = false;
                 return new ResultOfOperation(true, "Odhlášení OK");
             }
             else return new ResultOfOperation(false, "Nelze se odhlásit - ještě nejste on-line");
        }




         public ResultOfOperation All_users_list(User user)
         {
             if (user.on_line) {
                 object[] result = proxy.Invoke("All_users_list", new object[] {});
                 List<string> list = (List<string>) result[0];
                 for (int i = 0; i < list.Count; i++)
                     Console.WriteLine("Nick: {0}, Stav: {1}", list[i], list[++i]);
                 return new ResultOfOperation(true,"");
             }
             else return new ResultOfOperation(false,"jste off_line");
         }




         public ResultOfOperation Online_users_list(User user)
         {
             if (user.on_line) {
                 object[] result = proxy.Invoke("Online_users_list", new object[] {});
                 List<string> list = (List<string>) result[0];
                 for (int i = 0; i < list.Count; i++)
                     Console.WriteLine("Nick: {0}", list[i]);
                 return new ResultOfOperation(true,"");
             }
             else return new ResultOfOperation(false,"jste off_line");
         }




         public ResultOfOperation Set_chat_partners(User user, string[] partners)     //zatim neosetreno jestli partners jsou ok a online
         {
             string partner;
             int i = 0;
             if (user.on_line) {
                 Console.WriteLine("Postupně zadávejte partnery, ukončíte prázdným řetězcem.");
                 while ((partner = Console.ReadLine()) != "") partners[i++] = partner;
                 object[] result = proxy.Invoke("Set_chat_partners", new object[] {user.nick, partners});
                 if ((bool) result[0]) return new ResultOfOperation(true, "");
                 else return new ResultOfOperation(false, "");
             }
             else return new ResultOfOperation(false, "Nejste online");
         */
    }
}
