using System.Text.RegularExpressions;
using ModClient.MessageServices;

namespace ModClient.Plugins
{
    public class BibbaPlugin : Plugin
    {
        public BibbaPlugin(IServiceView service) : base(service)
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