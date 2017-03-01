using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModClient.MessageService.HackChat;
using ModClient.View;

namespace ModClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsoleChatView().Run();
        }
    }
}