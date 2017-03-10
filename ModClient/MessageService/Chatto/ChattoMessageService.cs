using System;
using System.Collections.Generic;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Proto;
using WebSocketSharp;

namespace ModClient.MessageService.Chatto
{
    public class ChattoMessageService : MessageServiceBase
    {
        public override string ServiceName { get; } = "Chatto";

        private WebSocket ws;

        public ChattoMessageService(string url, string name, string pass, string room)
        {
            Username = name;
            Channel = room;

            ws = new WebSocket(url);
            ws.OnOpen += (sender, args) =>
            {
                ws.Send(new Join
                {
                    Name = name,
                    Password = pass,
                    Room = room
                }.ToByteArray());
            };

            ws.OnMessage += (sender, args) =>
            {
                var chat = ChatFromServer.Parser.ParseFrom(args.RawData);
                OnMessageRecievedInternal(new Message(chat.Name, chat.Trip, chat.Text,
                    new List<RichTextNode> {new RichTextNode(chat.Text, RichTextNode.NodeType.Text)}, false,
                    DateTime.Now));
            };

            ws.Connect();
        }

        public override void SendMessage(string message)
        {
            ws.Send(new ChatToServer {Text = message}.ToByteArray());
        }

        public override void Close()
        {
            ws.Close();
        }
    }
}