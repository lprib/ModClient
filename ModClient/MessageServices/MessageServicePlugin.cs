using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using ModClient.Plugins;
using ModClient.Plugins.DefaultPlugins;

namespace ModClient.MessageServices
{
    partial class MessageService
    {
        public abstract class Plugin
        {
            public MessageService Service { get; }

            public string Username { get; }

            public string Channel { get; }

            public string ServiceName { get; }

            public virtual List<ConfigOption> ConfigOptions { get; } = new List<ConfigOption>();

            public IReadOnlyList<Plugin> OtherPlugins { get; }

            public abstract string PluginName { get; }

            protected Plugin(MessageService service)
            {
                service.plugins.Add(this);

                Service = service;
                Username = service.Username;
                Channel = service.Channel;
                ServiceName = service.ServiceName;

                OtherPlugins = service.plugins.AsReadOnly();
            }

            public void SendMessage(string message) => Service.SendMessage(message);
            public void LocalOutput(string message) => Service.OnLocalOutput(message);
            public void Close() => Service.Close();

            public virtual string PreprocessOutgoingMessage(string message)
            {
                return message;
            }

            public virtual void OnMessage(Message message)
            {
            }

            public virtual void OnInfo(InfoType type, object data)
            {
            }

            public virtual void OnLocalOutput(string output)
            {
            }

            public static List<Tuple<string, Type>> Defaults = new List<Tuple<string, Type>>
            {
                Tuple.Create("Bibba", typeof(BibbaPlugin)),
                Tuple.Create("config test", typeof(ConfigOptionsTest)),
                Tuple.Create("response", typeof(ResponsePlugin)),
                Tuple.Create("text corrector", typeof(TextCorrectionPlugin)),
            };
        }
    }
}