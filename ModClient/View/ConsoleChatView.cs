using System;
using ModClient.MessageServices;
using ModClient.MessageServices.HackChat;
using static System.ConsoleColor;

namespace ModClient.View
{
    public class ConsoleChatView
    {
        private readonly ConsoleColor[] usernameColors = {Blue, Cyan, Red, Magenta};
        private MessageService.Plugin viewPlugin;

        public void Run()
        {
            Console.Write("Channel:");
            var chan = Console.ReadLine();
            Console.Write("Username:");
            var username = Console.ReadLine();
            Console.Write("Password:");
            var pass = Console.ReadLine();
            Console.Clear();

            var service = new HackChatMessageService(username, pass, chan);
            viewPlugin = new ConsoleChatViewPlugin(service, this);

            while (true)
            {
                viewPlugin.SendMessage(Console.ReadLine());
                Console.CursorTop--;
            }
        }

        private void OnMessageRevieved(Message message)
        {
            Console.Write($"{message.Time :hh:mmtt} {message.SenderTrip + " " + message.SenderName,25}: ");
            foreach (var node in message.RichText)
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

        private class ConsoleChatViewPlugin : MessageService.Plugin
        {
            private ConsoleChatView view;

            public ConsoleChatViewPlugin(MessageService service, ConsoleChatView view) : base(service)
            {
                this.view = view;
            }

            public override void OnMessage(Message message)
            {
                view.OnMessageRevieved(message);
            }

            public override string PluginName { get; } = "Console UI";
        }
    }
}