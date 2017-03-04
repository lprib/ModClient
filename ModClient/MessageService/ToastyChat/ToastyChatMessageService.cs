using ModClient.MessageService.HackChat;

namespace ModClient.MessageService.ToastyChat
{
    public class ToastyChatMessageService : HackChatMessageService
    {
        public ToastyChatMessageService(string username, string password, string channel)
            : base(username, password, channel)
        {
        }

        protected override string Url { get; } = "wss://chat.toastystoemp.com/chatws";
        public override string ServiceName { get; } = "ToastyChat";

        protected override string GetJoinString(string username, string password, string channel)
        {
            //toastychat has an explicit password field on join string, unlike hack.chat's "username#password"
            return
                $"{{\"cmd\": \"join\", \"channel\": \"{channel}\", \"nick\": \"{username}\", \"password\": \"{password}\"}}";
        }
    }
}