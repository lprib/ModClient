using System.Collections.Generic;
using ModClient.Plugins;

namespace ModClient.MessageServices
{
    //a service that fires events in the event of an incoming message, and includes the ability to send messages
    public abstract class MessageService
    {
        private List<IServiceView> views = new List<IServiceView>();

        protected string Username { get; set; }
        protected string Channel { get; set; }

        //base classes override to set their name
        //sorta like a static overrideable value
        public abstract string ServiceName { get; }

        protected List<string> OnlineUsers { get; set; } = new List<string>();

        protected event MessageEventHandler OnMessageRecieved;
        protected event InfoEventHandler OnInfoRecieved;
        protected event PluginOutputEventHandler OnPluginOutput;

        protected abstract void SendMessage(string message);
        protected abstract void Close();

        public IServiceView GetView()
        {
            var newView = new InternalServiceView(this);
            views.Add(newView);
            return newView;
        }

        //call this within the SendMessage Fucntion
        //null string means no message should be sent
        protected string DoMessagePreprocess(string message)
        {
            //todo test this logic
            foreach (var view in views)
            {
                var internalView = (InternalServiceView) view;
                if (internalView.IsPreprocessingOutgoingMessages)
                {
                    message = ((InternalServiceView) view).PreprocessOutgoingMessage(message);

                    if (message == null) break;
                }
            }
            return message;
        }

        protected void OnMessageRecievedInternal(Message message) => OnMessageRecieved?.Invoke(message);
        protected void OnInfoRecievedInternal(InfoType type, object data) => OnInfoRecieved?.Invoke(type, data);

        private class InternalServiceView : IServiceView
        {
            private readonly MessageService parent;
            private bool subscribed = true;

            public InternalServiceView(MessageService parent)
            {
                this.parent = parent;

                parent.OnMessageRecieved += OnMessage;
                parent.OnInfoRecieved += OnInfo;
                parent.OnPluginOutput += OnPluginOutput;

                OnlineUsers = parent.OnlineUsers;
                Username = parent.Username;
                Channel = parent.Channel;
                ServiceName = parent.ServiceName;
            }

            public List<string> OnlineUsers { get; }
            public event MessageEventHandler OnMessage;
            public event InfoEventHandler OnInfo;
            public event PluginOutputEventHandler OnPluginOutput;
            public event OutgoingMessageEventHandler OnOutgoingMessage;

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

            public void Unsubscribe()
            {
                parent.OnMessageRecieved -= OnMessage;
                parent.OnInfoRecieved -= OnInfo;
                parent.OnPluginOutput -= OnPluginOutput;

                subscribed = false;
            }

            public string Username { get; }
            public string Channel { get; }
            public string ServiceName { get; }

            //event invocators (for use inside this class only)
            internal string PreprocessOutgoingMessage(string message) => OnOutgoingMessage?.Invoke(message);

            //is the proprocess event subscribed?
            internal bool IsPreprocessingOutgoingMessages => OnOutgoingMessage != null;
        }
    }
}