using System.Text.RegularExpressions;
using ModClient.MessageServices;

namespace ModClient.Plugins.DefaultPlugins
{
    public class BibbaPlugin : MessageService.Plugin
    {
        public BibbaPlugin(MessageService view) : base(view)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            message = Regex.Replace(message, "who", "whom'st've");
            message = Regex.Replace(message, "[bcdgp]", "🅱️");

            return message;
        }

        public override string ToString() => "Bibba";
        public override string PluginName { get; } = "Bibba";
    }
}