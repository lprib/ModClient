using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModClient.MessageService
{
    delegate void MessageRecievedDelegate(Message message);

    delegate void InfoRecievedDelegate(Dictionary<string, object> info);

    //if not isJoin, user left
    delegate void OnJoinLeaveDelegate(bool isJoin, string user);

    //a service that fires events in the event of an incoming message, and includes the ability to send messages
    interface IMessageService
    {
        string Username { get; }
        string Channel { get; }

        IList<string> OnlineUsers { get; }

        event MessageRecievedDelegate OnMessageRecieved;
        event OnJoinLeaveDelegate OnJoinLeave;

        void SendMessage(string message);
    }
}