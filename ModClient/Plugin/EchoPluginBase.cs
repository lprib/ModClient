using ModClient.MessageService;

namespace ModClient.Plugin
{
    public class EchoPluginBase : PluginBase
    {
        private MessageService.MessageServiceBase serviceBase;

        public EchoPluginBase(MessageService.MessageServiceBase serviceBase) : base(serviceBase)
        {
            serviceBase.OnMessageRecieved += OnMessage;
        }

        private void OnMessage(Message message)
        {
            if (message.PlainText.ToLower() == "echo")
            {
                serviceBase.SendMessage("echo!");
            }
        }
    }
}