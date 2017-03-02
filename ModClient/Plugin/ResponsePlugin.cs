using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class ResponsePlugin : PluginBase
    {
        private Dictionary<string, string> responses = new Dictionary<string, string>();
        private const string trigger = "/response ";
        private readonly Regex addResponseRegex = new Regex(@"^add ""([^""]+)"" ""([^""]+)""");

        public ResponsePlugin(MessageServiceBase service) : base(service)
        {
        }

        public override string PreprocessOutgoingMessage(string message)
        {
            if (!message.StartsWith(trigger))
                return message;

            var newMessage = message.Substring(trigger.Length);
            if (newMessage.StartsWith("add"))
            {
                var match = addResponseRegex.Match(newMessage);
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
            {
                if (message.PlainText.ToLower() == response.Key)
                {
                    ParentService.SendMessage(response.Value);
                }
            }
        }
    }
}