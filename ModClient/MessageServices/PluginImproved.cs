namespace ModClient.MessageServices
{
    public class PluginImproved
    {
        public IServiceView View { get; }

        public PluginImproved(IServiceView view)
        {
            View = view;
        }

        public virtual void OnMessageRecieved(Message message)
        {
        }

        public virtual void OnInfoRecieved(InfoType type, object data)
        {
        }

        public virtual void OnPluginOutput(string output)
        {
        }
    }
}