using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModClient.MessageServices;

namespace ModClient.Plugins.DefaultPlugins
{
    public class ResponsePlugin : MessageService.Plugin
    {
        private static readonly Regex AddResponseRegex = new Regex(@"^add ""([^""]+)"" ""([^""]+)""");
        private readonly Dictionary<string, string> responses = new Dictionary<string, string>();

        private readonly List<ConfigOption> options = new List<ConfigOption>
        {
            new ConfigOption("Trigger", ConfigOption.Type.Text) {Data = "/response "}
        };

        public ResponsePlugin(MessageService service) : base(service)
        {
        }

        public override List<ConfigOption> ConfigOptions => options;

        public override string PreprocessOutgoingMessage(string message)
        {
            var trigger = (string) options[0].Data;
            if (!message.StartsWith(trigger))
                return message;

            var newMessage = message.Substring(trigger.Length);
            if (newMessage.StartsWith("add"))
            {
                var match = AddResponseRegex.Match(newMessage);
                var newTrigger = match.Groups[1].Value;
                var newResponse = match.Groups[2].Value;
                responses.Add(newTrigger, newResponse);
                LocalOutput($"Added: trigger={newTrigger} response={newResponse}");
            }
            else if (newMessage.StartsWith("clear"))
            {
                responses.Clear();
                LocalOutput("Cleared trigger/responses");
            }
            else
            {
                LocalOutput("Unknown command: " + message);
            }
            return null;
        }

        public override void OnMessage(Message message)
        {
            foreach (var response in responses)
                if (message.PlainText.ToLower() == response.Key)
                    SendMessage(response.Value);
        }

        public override string PluginName { get; } = "Automated Response";
    }
}