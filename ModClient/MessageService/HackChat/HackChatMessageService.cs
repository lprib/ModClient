using System;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ModClient.MessageService;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace ModClient.MessageService.HackChat
{
    public class HackChatMessageService : IMessageService
    {
        public string Channel { get; }
        public string Username { get; }

        public IList<string> OnlineUsers { get; private set; }

        public event MessageRecievedDelegate OnMessageRecieved;
        public event InfoRecievedDelegate OnInfoRecieved;

        private WebSocket webSocket;
        private Thread pingThread;


        public HackChatMessageService(string username, string password, string channel)
        {
            Username = username;
            Channel = channel;

            pingThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(300));
                    }
                    catch (ThreadInterruptedException _)
                    {
                        Console.WriteLine(_);
                        //do nothing, we want thread to be interrupted on close
                    }
                    webSocket.Send("{\"cmd\": \"ping\"}");
                }
            });

            webSocket = new WebSocket("wss://hack.chat/chat-ws");
            webSocket.OnMessage += OnWebSocketMessage;
            webSocket.OnOpen +=
                (s, args) =>
                {
                    webSocket.Send(
                        $"{{\"cmd\": \"join\", \"channel\": \"{Channel}\", \"nick\": \"{Username}#{password}\"}}");
                    pingThread.Start();
                };
            webSocket.OnClose += (s, args) => pingThread.Interrupt();
            webSocket.Connect();
        }

        private void OnWebSocketMessage(object sender, MessageEventArgs e)
        {
            var messageJson = JObject.Parse(e.Data);

            var command = (string) messageJson["cmd"];
            switch (command)
            {
                case "chat":
                    var time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        .AddMilliseconds((double) messageJson["time"]);
                    time = time.ToLocalTime();

                    var text = (string) messageJson["text"];
                    var nick = (string) messageJson["nick"];
                    var trip = (string) messageJson["trip"];

                    var richText = HackChatTextParser.GetRichText(text, this);
                    var message = new Message(nick, trip, text, richText, text.ToLower().Contains(Username.ToLower()),
                        time);

                    OnMessageRecieved?.Invoke(message);
                    break;
                case "onlineSet":
                    OnlineUsers = messageJson["nicks"].ToObject<List<string>>();
                    OnInfoRecieved?.Invoke(InfoType.OnlineSet, OnlineUsers);
                    break;
                case "onlineAdd":
                    var addNick = (string) messageJson["nick"];
                    OnlineUsers.Add(addNick);
                    OnInfoRecieved?.Invoke(InfoType.OnlineAdd, addNick);
                    break;
                case "onlineRemove":
                    var removeNick = (string) messageJson["nick"];
                    OnlineUsers.Remove(removeNick);
                    OnInfoRecieved?.Invoke(InfoType.OnlineRemove, removeNick);
                    break;
                default:
                    Debug.WriteLine("Unrecognised message:");
                    Debug.WriteLine(e.Data);
                    break;
            }
        }

        public void SendMessage(string message)
        {
            var serialized =
                JsonConvert.SerializeObject(new Dictionary<string, string> {{"cmd", "chat"}, {"text", message}});
            webSocket.Send(serialized);
        }

        public void Close()
        {
            webSocket.Close();
        }
    }
}