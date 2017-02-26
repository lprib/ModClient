using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModClient.MessageService
{
    public delegate void MessageRecievedDelegate(Message message);

    public delegate void InfoRecievedDelegate(InfoType type, object data);

    //a service that fires events in the event of an incoming message, and includes the ability to send messages
    public interface IMessageService
    {
        string Username { get; }
        string Channel { get; }

        IList<string> OnlineUsers { get; }

        event MessageRecievedDelegate OnMessageRecieved;
        event InfoRecievedDelegate OnInfoRecieved;

        void SendMessage(string message);
        void Close();
    }
}