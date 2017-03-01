using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModClient.MessageService;
using ModClient.MessageService.HackChat;
using static System.ConsoleColor;

namespace ModClient.View
{
    public class ConsoleChatView
    {
        private HackChatMessageService service;
        private ConsoleColor[] usernameColors = {Blue, Cyan, Red, Magenta};

        public ConsoleChatView()
        {
        }

        public void Run()
        {
            Console.Write("Channel:");
            var chan = Console.ReadLine();
            Console.Write("Username:");
            var username = Console.ReadLine();
            Console.Write("Password:");
            var pass = Console.ReadLine();
            Console.Clear();

            service = new HackChatMessageService(username, pass, chan);
            //service.OnJoinLeave += (isJoin, user) => Console.WriteLine(user + (isJoin ? " joined." : " left."));
            service.OnMessageRecieved += OnMessageRevieved;

            while (true)
            {
                service.SendMessage(Console.ReadLine());
                Console.CursorTop--;
            }
        }

        private void OnMessageRevieved(Message message)
        {
            Console.Write($"{message.Time :hh:mmtt} {message.SenderTrip + " " + message.SenderName ,25}: ");
            foreach (var node in message.RichText)
            {
                switch (node.Type)
                {
                    case RichTextNode.NodeType.Text:
                        WriteColor(node.Value, message.IsSelfMention ? Green : White);
                        break;
                    case RichTextNode.NodeType.Username:
                        WriteColor(node.Value, GetConsoleColor(node.Value));
                        break;
                    case RichTextNode.NodeType.Formatted:
                        WriteColor(node.Value, Yellow);
                        break;
                }
            }
            Console.WriteLine();
        }

        private ConsoleColor GetConsoleColor(string name)
            => usernameColors[Math.Abs(name.GetHashCode()) % usernameColors.Length];

        private void WriteColor(string str, ConsoleColor foreground)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.Write(str);
            Console.ForegroundColor = oldColor;
        }
    }
}