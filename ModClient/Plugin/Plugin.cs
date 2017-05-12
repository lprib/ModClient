using System;
using System.Collections.Generic;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public delegate void PluginOutputDelegate(string message);

    //A plugin is a add-on to a MessageServiceBase
    //it can subscribe to all MessageServiceBase events, and send messages
    //also has the ability to preprocess text before it is sent to the backend/server
    public abstract class Plugin
    {
        private bool enabled;
        protected MessageServiceBase ParentService;

        protected Plugin(MessageServiceBase service)
        {
            ParentService = service;
            Enabled = true;
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (!enabled && value)
                    OnEnabled();
                if (enabled && !value)
                    OnDisabled();
                enabled = value;
            }
        }

        //pugins can supply output messages to the user
        internal event PluginOutputDelegate OnPluginOutput;

        //return null if no message should be sent
        //only called if plugin.Enabled == true
        public virtual string PreprocessOutgoingMessage(string message) => message;

        protected virtual void OnEnabled()
        {
        }

        protected virtual void OnDisabled()
        {
        }

        protected void PluginOutput(string message) => OnPluginOutput?.Invoke(message);

        //override this and return a list to enable options
        public virtual List<ConfigOption> GetConfigOptions()
        {
            return new List<ConfigOption>();
        }


        public static List<Tuple<string, Type>> DefaultPlugins = new List<Tuple<string, Type>>
        {
            Tuple.Create("Bibba", typeof(BibbaPlugin)),
            Tuple.Create("Text Corrector", typeof(TextCorrectionPlugin)),
            Tuple.Create("Automatic Response", typeof(ResponsePlugin)),
            Tuple.Create("options test", typeof(ConfigOptionsTest)),
        };
    }
}