using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class ConfigOptionsTest : PluginBase
    {
        private List<ConfigOption> options = new List<ConfigOption>();

        public ConfigOptionsTest(MessageServiceBase service) : base(service)
        {
            options.Add(new ConfigOption("henlo", ConfigOption.Type.Boolean));
            options.Add(new ConfigOption("owo", ConfigOption.Type.Text));
            options.Add(new ConfigOption("en button", ConfigOption.Type.Button));
        }

        public override List<ConfigOption> GetConfigOptions() => options;

        public override string ToString() => "Options Test";
    }
}