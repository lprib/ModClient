using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class ConfigOptionsTest : Plugin
    {
        private List<ConfigOption> options = new List<ConfigOption>();
        public override List<ConfigOption> ConfigOptions => options;

        public ConfigOptionsTest(MessageServiceBase service) : base(service)
        {
            options = new List<ConfigOption>
            {
                new ConfigOption("Boolean option", ConfigOption.Type.Boolean,
                    (val, newVal) => PluginOutput($"Boolean changed: {val} to {newVal}")),
                new ConfigOption("Text option", ConfigOption.Type.Text,
                    (val, newVal) => PluginOutput($"Text changed: {val} to {newVal}")),
                new ConfigOption("Button option", ConfigOption.Type.Button,
                    (val, newVal) => PluginOutput("Button 1 pressed")),
                new ConfigOption("Another utton option", ConfigOption.Type.Button,
                    (val, newVal) => PluginOutput("Button 2 pressed")),
            };

            service.OnMessageRecieved += message => { Console.WriteLine(message.PlainText); };
        }

        public override string ToString() => "Options Test";
    }
}