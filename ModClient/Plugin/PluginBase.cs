using ModClient.MessageService;

namespace ModClient.Plugin
{
    //A plugin is a add-on to a MessageServiceBase
    //it can subscribe to all MessageServiceBase events, and send messages
    //also has the ability to preprocess text before it is sent to the backend/server
    public abstract class PluginBase
    {
        protected MessageService.MessageServiceBase ParentService;

        public PluginBase(MessageService.MessageServiceBase service)
        {
            ParentService = service;
        }

        //return null if no message should be sent
        public virtual string PreprocessOutgoingMessage(string message) => message;
    }
}