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

        public ConfigOptionsTest(MessageServiceBase service) : base(service)
        {
            var option1 = new ConfigOption("henlo", ConfigOption.Type.Boolean);
            option1.OnChanged += (val, newVal) => Console.WriteLine($"henlo {val} {newVal}");
            var option2 = new ConfigOption("owo", ConfigOption.Type.Text);
            option2.OnChanged += (val, newVal) => Console.WriteLine($"owo {val} {newVal}");
            var option3 = new ConfigOption("en button", ConfigOption.Type.Button);
            option3.OnChanged += (val, newVal) => Console.WriteLine($"en button {val} {newVal}");
            options.Add(option1);
            options.Add(option2);
            options.Add(option3);
        }

        public override List<ConfigOption> GetConfigOptions() => options;

        public override string ToString() => "Options Test";
    }
}