using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class BibbaPlugin: PluginBase
    {
        public BibbaPlugin(MessageServiceBase service) : base(service)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            Console.WriteLine("henlo");
            message = Regex.Replace(message, "who", "whom'st've");
            message = Regex.Replace(message, "[bcdgp]", "🅱️");

            return message;
        }
    }
}
