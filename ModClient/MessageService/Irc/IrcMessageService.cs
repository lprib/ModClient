using System;
using System.Collections.Generic;
using ChatSharp;

namespace ModClient.MessageService.Irc
{
    public class IrcMessageService : MessageServiceBase
    {
        private readonly IrcClient client;

        public IrcMessageService(string server, string channel, string username, string password)
        {
            client = new IrcClient(server, new IrcUser(username, username, password));
            client.ConnectionComplete += (sender, args) => client.JoinChannel(channel);

            client.ChannelMessageRecieved += (sender, args) =>
            {
                var user = args.PrivateMessage.User.User;
                var text = args.PrivateMessage.Message;

                OnMessageRecievedInternal(new Message(user, null, text,
                    new List<RichTextNode> {new RichTextNode(text, RichTextNode.NodeType.Text)}, false, DateTime.Now));
            };
        }

        public override string ServiceName { get; } = "IRC";

        protected override void SendMessage(string message)
        {
            client.SendMessage(message);
        }

        protected override void Close()
        {
            client.Quit();
        }
    }
}