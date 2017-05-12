using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class ResponsePlugin : Plugin
    {
        private List<ConfigOption> options = new List<ConfigOption>()
        {
            new ConfigOption("Trigger", ConfigOption.Type.Text) {Data = "/response"}
        };

        private static readonly Regex AddResponseRegex = new Regex(@"^add ""([^""]+)"" ""([^""]+)""");
        private readonly Dictionary<string, string> responses = new Dictionary<string, string>();

        public ResponsePlugin(MessageServiceBase service) : base(service)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            var trigger = (string)options[0].Data;
            if (!message.StartsWith(trigger))
                return message;

            var newMessage = message.Substring(trigger.Length);
            if (newMessage.StartsWith("add"))
            {
                var match = AddResponseRegex.Match(newMessage);
                var newTrigger = match.Groups[1].Value;
                var newResponse = match.Groups[2].Value;
                responses.Add(newTrigger, newResponse);
                PluginOutput($"Added: trigger={newTrigger} response={newResponse}");
            }
            else if (newMessage.StartsWith("clear"))
            {
                responses.Clear();
                PluginOutput("Cleared trigger/responses");
            }
            else
            {
                PluginOutput("Unknown command: " + message);
            }
            return null;
        }

        protected override void OnEnabled() => ParentService.OnMessageRecieved += OnMessage;

        protected override void OnDisabled() => ParentService.OnMessageRecieved -= OnMessage;

        private void OnMessage(Message message)
        {
            foreach (var response in responses)
                if (message.PlainText.ToLower() == response.Key)
                    ParentService.SendMessage(response.Value);
        }

        public override List<ConfigOption> GetConfigOptions() => options;
    }
}