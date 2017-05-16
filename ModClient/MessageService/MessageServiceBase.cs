using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageService
{
    public delegate void MessageRecievedDelegate(Message message);

    public delegate void InfoRecievedDelegate(InfoType type, object data);

    //a service that fires events in the event of an incoming message, and includes the ability to send messages
    public abstract class MessageServiceBase
    {
        private List<ServiceView> views = new List<ServiceView>();

        protected MessageServiceBase()
        {
            Plugins = internalPlugins.AsReadOnly();
        }

        protected string Username { get; set; }
        protected string Channel { get; set; }

        //base classes override to set their name
        //sorta like a static overrideable value
        public abstract string ServiceName { get; }

        protected List<string> OnlineUsers { get; set; } = new List<string>();

        private List<Plugin> internalPlugins { get; } = new List<Plugin>();
        protected IReadOnlyList<Plugin> Plugins { get; }

        protected event MessageRecievedDelegate OnMessageRecieved;
        protected event InfoRecievedDelegate OnInfoRecieved;
        protected event PluginOutputDelegate OnPluginOutput;

        protected abstract void SendMessage(string message);
        protected abstract void Close();

        public ServiceView GetView()
        {
            return new InternalServiceView(this);
        }

        public void AddPlugin(Plugin plugin)
        {
            internalPlugins.Add(plugin);
            //capture all the output from running plugins, and re-transmit it through the OnPluginOutput event
            plugin.OnPluginOutput += message => OnPluginOutput?.Invoke(message);
        }

        public void RemovePlugin(Plugin plugin)
        {
            //TODO do something
        }

        //call this within the SendMessage Fucntion
        //null string means no message should be sent
        protected string PluginProcess(string message)
        {
            foreach (var plugin in Plugins)
            {
                if (plugin.Enabled)
                    message = plugin.PreprocessOutgoingMessage(message);

                if (message == null) break;
            }
            return message;
        }

        protected void OnMessageRecievedInternal(Message message) => OnMessageRecieved?.Invoke(message);
        protected void OnInfoRecievedInternal(InfoType type, object data) => OnInfoRecieved?.Invoke(type, data);

        private class InternalServiceView : ServiceView
        {
            private readonly MessageServiceBase parent;
            private bool subscribed = true;

            public InternalServiceView(MessageServiceBase parent)
            {
                this.parent = parent;

                parent.OnMessageRecieved += OnMessageRecieved;
                parent.OnInfoRecieved += OnInfoRecieved;
                parent.OnPluginOutput += OnPluginOutput;

                OnlineUsers = parent.OnlineUsers;
                Username = parent.Username;
                Channel = parent.Channel;
                ServiceName = parent.ServiceName;
            }

            public List<string> OnlineUsers { get; }
            public event MessageRecievedDelegate OnMessageRecieved;
            public event InfoRecievedDelegate OnInfoRecieved;
            public event PluginOutputDelegate OnPluginOutput;

            public void SendMessage(string message)
            {
                if (subscribed)
                    parent.SendMessage(message);
            }

            public void Close()
            {
                if (subscribed)
                    parent.Close();
            }

            public void AddPlugin(Plugin plugin)
            {
                if (subscribed)
                    parent.AddPlugin(plugin);
            }

            public void Unsubscribe()
            {
                parent.OnMessageRecieved -= OnMessageRecieved;
                parent.OnInfoRecieved -= OnInfoRecieved;
                parent.OnPluginOutput -= OnPluginOutput;

                subscribed = false;
            }

            public void RemovePlugin(Plugin plugin)
            {
                if (subscribed)
                    parent.RemovePlugin(plugin);
            }

            public string Username { get; }
            public string Channel { get; }
            public string ServiceName { get; }
            public IReadOnlyList<Plugin> Plugins { get; }
        }
    }
}