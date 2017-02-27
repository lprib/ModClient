using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class EchoPlugin : PluginBase
    {
        public EchoPlugin(MessageServiceBase service) : base(service)
        {
            service.OnMessageRecieved += OnMessage;
        }

        private void OnMessage(Message message)
        {
            if (message.PlainText.ToLower() == "echo")
                ParentService.SendMessage("echo!");
        }
    }
}