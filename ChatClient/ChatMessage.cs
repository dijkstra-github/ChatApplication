using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class ChatMessage
    {
        private string message;
        private User who;

        public ChatMessage()
        {}

        public ChatMessage(User who, string message)
        {
            this.message = message;
            this.who = who;
        }

        public ResultOfOperation Send()
        {   
            bool success = false;                    
            using (var chatServiceClient = new ChatService.WebService1SoapClient())
            {
                success = chatServiceClient.SendMessage("Karel", message);
            }

            ResultOfOperation result = null;
            if (success)
                result = new ResultOfOperation(success, "Poslano");
            else
                result = new ResultOfOperation(success, "Chyba");

            return result;
            //ChatService.WebService1SoapClient client = null;
            //try
            //{
            //    client = new ChatService.WebService1SoapClient();
            //    // neco budu s clientem delat
            //}
            //finally
            //{
            //    client.Close();
            //}
            //if (who.on_line & who.set_partners)
            //{
               
            //    proxy.Invoke("SendMessage", new object[] { who.nick, message });
            //    return new ResultOfOperation(true, "");
            //}
            //else return new ResultOfOperation(false, "Nejste on_line, nebo nemáte nastaveny partnery");
        }
    }
}
