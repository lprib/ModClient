using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageServices
{
    public delegate void MessageEventHandler(Message message);

    public delegate void InfoEventHandler(InfoType type, object data);

    public delegate void PluginOutputEventHandler(string message);

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
        event PluginOutputEventHandler OnPluginOutput;

        event OutgoingMessageEventHandler OnOutgoingMessage;

        void SendMessage(string message);
        void Close();

        void Unsubscribe();
    }
}