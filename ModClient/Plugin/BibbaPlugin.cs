using System.Text.RegularExpressions;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class BibbaPlugin : PluginBase
    {
        public BibbaPlugin(MessageServiceBase service) : base(service)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            message = Regex.Replace(message, "who", "whom'st've");
            message = Regex.Replace(message, "[bcdgp]", "🅱️");

            return message;
        }
    }
}