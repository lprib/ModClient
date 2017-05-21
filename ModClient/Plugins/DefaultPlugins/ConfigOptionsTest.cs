using System;
using System.Collections.Generic;
using ModClient.MessageServices;

namespace ModClient.Plugins.DefaultPlugins
{
    public class ConfigOptionsTest : MessageService.Plugin
    {
        public ConfigOptionsTest(MessageService service) : base(service)
        {
            ConfigOptions = new List<ConfigOption>
            {
                new ConfigOption("Boolean option", ConfigOption.Type.Boolean,
                    (val, newVal) => LocalOutput($"Boolean changed: {val} to {newVal}")),
                new ConfigOption("Text option", ConfigOption.Type.Text,
                    (val, newVal) => LocalOutput($"Text changed: {val} to {newVal}")),
                new ConfigOption("Button option", ConfigOption.Type.Button,
                    (val, newVal) => LocalOutput("Button 1 pressed")),
                new ConfigOption("Another utton option", ConfigOption.Type.Button,
                    (val, newVal) => LocalOutput("Button 2 pressed"))
            };
        }

        public override List<ConfigOption> ConfigOptions { get; } = new List<ConfigOption>();

        public override string PluginName { get; } = "Config Options Test";
    }
}