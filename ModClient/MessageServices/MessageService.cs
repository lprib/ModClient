using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageServices
{
    //a Service that fires events in the event of an incoming message, and includes the ability to send messages
    public abstract partial class MessageService
    {
        private List<Plugin> plugins = new List<Plugin>();

        public string Username { get; set; }
        public string Channel { get; set; }

        //base classes override to set their name
        //sorta like a static overrideable value
        public abstract string ServiceName { get; }

        public List<string> OnlineUsers { get; protected set; } = new List<string>();

        protected abstract void SendMessage(string message);
        protected abstract void Close();

        //call this within the SendMessage Fucntion
        //null string means no message should be sent
        protected string DoMessagePreprocess(string message)
        {
            //todo test this logic
            foreach (var plugin in plugins)
            {
                message = plugin.PreprocessOutgoingMessage(message);
            }

            return message;
        }

        protected void OnMessage(Message message)
        {
            foreach (var plugin in plugins)
            {
                plugin.OnMessage(message);
            }
        }

        protected void OnInfo(InfoType type, object data)
        {
            foreach (var plugin in plugins)
            {
                plugin.OnInfo(type, data);
            }
        }

        protected void OnLocalOutput(string output)
        {
            foreach (var plugin in plugins)
            {
                plugin.OnLocalOutput(output);
            }
        }
    }
}