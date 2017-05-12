using System.Text.RegularExpressions;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class BibbaPlugin : Plugin
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

        public override string ToString() => "Bibba";
    }
}