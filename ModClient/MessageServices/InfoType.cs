namespace ModClient.MessageServices
{
    //the type of info that was recieved from a MessageService
    public enum InfoType
    {
        #region Hack.chat events

        OnlineSet, //List<string> nicks
        OnlineAdd, //string nick
        OnlineRemove, //string nick
        ChannelRatelimit, //null
        MessageRatelimit, //null
        UserBan, //string nick
        UserInvite, //string[] {nick, channel}
        UsernameTaken, //null
        InvalidUsername, //null
        ImpersonatingAdmin //null

        #endregion
    }
}