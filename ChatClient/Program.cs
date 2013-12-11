using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
   
   
        class Chat
        {
        
            static void Main(string[] args)
            {
                ChatCommand com;
                ChatMessage mess;
                User user = new User();
                ResultOfOperation result;

                do
                {
                    Console.Write("input> ");
                    string input = Console.ReadLine();
                    if (input[0] == '#') {
                        com = new ChatCommand(user, input);
                        result = com.Execute();
                        Console.WriteLine(result.message);
                    }
                    else {
                        mess = new ChatMessage(user, input);
                        result = mess.Send();
                        Console.WriteLine(result.message);
                    }
                }
                while (!result.end_command_indicator);

                return;
            }
        }
    }
