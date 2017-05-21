using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageServices
{
    public delegate void MessageEventHandler(Message message);

    public delegate void InfoEventHandler(InfoType type, object data);

    public delegate void LocalOutputEventHandler(string message);

    public delegate string OutgoingMessageEventHandler(string outgoingMessage);

    //this interface provides a one-way view into a messageservice
    public interface IServiceView
    {
        List<string> OnlineUsers { get; }
        string Username { get; }
        string Channel { get; }
        string ServiceName { get; }

        event MessageEventHandler OnMessage;
        event InfoEventHandler OnInfo;
        event LocalOutputEventHandler OnLocalOutput;

        event OutgoingMessageEventHandler OnOutgoingMessage;

        void SendMessage(string message);
        void LocalOutput(string message);

        void Close();

        void Unsubscribe();
    }

    public class IHateRefactoring
    {
        private MessageService service;
        private bool isSubscribed = true;

        public IHateRefactoring(MessageService service)
        {
            this.service = service;
        }

        public List<string> OnlineUsers { get; }
        public string Username { get; }
        public string Channel { get; }
        public string ServiceName { get; }

        event MessageEventHandler OnMessage;
        event InfoEventHandler OnInfo;
        event LocalOutputEventHandler OnLocalOutput;

        event OutgoingMessageEventHandler OnOutgoingMessage;

        void SendMessage(string message)
        {
            
        }

        void LocalOutput(string message)
        {
            
        }

        void Close()
        {
            
        }

        void Unsubscribe()
        {
            
        }
    }
}