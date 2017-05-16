using System;
using System.Collections.Generic;
using ModClient.MessageService;

namespace ModClient.Plugins
{
    public class ConfigOptionsTest : Plugin
    {
        public ConfigOptionsTest(MessageServiceBase service) : base(service)
        {
            ConfigOptions = new List<ConfigOption>
            {
                new ConfigOption("Boolean option", ConfigOption.Type.Boolean,
                    (val, newVal) => PluginOutput($"Boolean changed: {val} to {newVal}")),
                new ConfigOption("Text option", ConfigOption.Type.Text,
                    (val, newVal) => PluginOutput($"Text changed: {val} to {newVal}")),
                new ConfigOption("Button option", ConfigOption.Type.Button,
                    (val, newVal) => PluginOutput("Button 1 pressed")),
                new ConfigOption("Another utton option", ConfigOption.Type.Button,
                    (val, newVal) => PluginOutput("Button 2 pressed"))
            };

            service.OnMessageRecieved += message => { Console.WriteLine(message.PlainText); };
        }

        public override List<ConfigOption> ConfigOptions { get; } = new List<ConfigOption>();

        public override string ToString() => "Options Test";
    }
}