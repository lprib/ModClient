﻿using System.Collections.Generic;
using ModClient.Plugin;

namespace ModClient.MessageService
{
    public delegate void MessageRecievedDelegate(Message message);

    public delegate void InfoRecievedDelegate(InfoType type, object data);

    //a service that fires events in the event of an incoming message, and includes the ability to send messages
    public abstract class MessageServiceBase
    {
        protected MessageServiceBase()
        {
            OnlineUsers = new List<string>();
            Plugins = new List<PluginBase>();
        }

        public string Username { get; protected set; }
        public string Channel { get; protected set; }

        //base classes override to set their name
        //sorta like a static overrideable value
        public abstract string ServiceName { get; }

        public IList<string> OnlineUsers { get; protected set; }
        public IList<PluginBase> Plugins { get; protected set; }

        public event MessageRecievedDelegate OnMessageRecieved;
        public event InfoRecievedDelegate OnInfoRecieved;
        public event PluginOutputDelegate OnPluginOutput;

        public abstract void SendMessage(string message);
        public abstract void Close();

        public void AddPlugin(PluginBase plugin)
        {
            Plugins.Add(plugin);
            //capture all the output from running plugins, and re-transmit it through the OnPluginOutput event
            plugin.OnPluginOutput += message => OnPluginOutput?.Invoke(message);
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
    }
}