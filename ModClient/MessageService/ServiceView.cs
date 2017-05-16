using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageService
{
    //this interface provides a view into a messageservice
    public interface ServiceView
    {
        List<string> OnlineUsers { get; }
        IReadOnlyList<Plugin> Plugins { get; }
        string Username { get; }
        string Channel { get; }
        string ServiceName { get; }

        event MessageRecievedDelegate OnMessageRecieved;
        event InfoRecievedDelegate OnInfoRecieved;
        event PluginOutputDelegate OnPluginOutput;

        void SendMessage(string message);
        void Close();

        void AddPlugin(Plugin plugin);
        void RemovePlugin(Plugin plugin);

        void Unsubscribe();
    }
}