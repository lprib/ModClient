using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace ModClient.MessageService.HackChat
{
    public class HackChatMessageService : MessageServiceBase
    {
        private readonly WebSocket webSocket;


        public HackChatMessageService(string username, string password, string channel)
        {
            Username = username;
            Channel = channel;

            var pingThread = new Thread(() =>
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

                    OnMessageRecievedInternal(message);
                    break;
                case "onlineSet":
                    OnlineUsers = messageJson["nicks"].ToObject<List<string>>();
                    OnInfoRecievedInternal(InfoType.OnlineSet, OnlineUsers);
                    break;
                case "onlineAdd":
                    var addNick = (string) messageJson["nick"];
                    OnlineUsers.Add(addNick);
                    OnInfoRecievedInternal(InfoType.OnlineAdd, addNick);
                    break;
                case "onlineRemove":
                    var removeNick = (string) messageJson["nick"];
                    OnlineUsers.Remove(removeNick);
                    OnInfoRecievedInternal(InfoType.OnlineRemove, removeNick);
                    break;
                case "warn":
                    var warnText = (string) messageJson["text"];
                    switch (warnText)
                    {
                        case "Nickname must consist of up to 24 letters, numbers, and underscores":
                            OnInfoRecievedInternal(InfoType.InvalidUsername, warnText);
                            break;
                        case "Cannot impersonate the admin":
                            OnInfoRecievedInternal(InfoType.ImpersonatingAdmin, warnText);
                            break;
                        case "Nickname taken":
                            OnInfoRecievedInternal(InfoType.UsernameTaken, warnText);
                            break;
                        case "You are joining channels too fast. Wait a moment and try again.":
                            OnInfoRecievedInternal(InfoType.ChannelRatelimit, warnText);
                            break;
                        case "You are sending too much text. Wait a moment and try again.\n" +
                             "Press the up arrow key to restore your last message.":
                            OnInfoRecievedInternal(InfoType.MessageRatelimit, warnText);
                            break;
                        default:
                            Console.WriteLine("Unrecognised warning:\n" + e.Data);
                            break;
                    }
                    break;

                default:
                    Debug.WriteLine("Unrecognised message:");
                    Debug.WriteLine(e.Data);
                    break;
            }
        }

        public override void SendMessage(string message)
        {
            message = PluginProcess(message);
            if (message == null) return;

            var serialized =
                JsonConvert.SerializeObject(new Dictionary<string, string> {{"cmd", "chat"}, {"text", message}});
            webSocket.Send(serialized);
        }

        public override void Close()
        {
            webSocket.Close();
        }
    }
}