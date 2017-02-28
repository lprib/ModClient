using System;
using System.Text.RegularExpressions;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class TextCorrectionPlugin : PluginBase
    {
        private Regex regex = new Regex(@"^s/([^/]+)/([^/]+)");
        private string previousMessage;

        public TextCorrectionPlugin(MessageServiceBase service) : base(service)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            var match = regex.Match(message);
            if (match.Success)
            {
                var replaced = previousMessage.Replace(match.Groups[1].Value, match.Groups[2].Value);
                ;
                //is there is no change, dont send a new message
                return replaced != message ? replaced : null;
            }
            previousMessage = message;
            return message;
        }
    }
}