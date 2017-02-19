using System;
using System.Collections.Generic;

namespace ModClient.MessageService
{
    class Message
    {
        public Message(string senderName, string senderTrip, string text, List<RichTextNode> richText,
            bool isSelfMention, DateTime time)
        {
            SenderName = senderName;
            SenderTrip = senderTrip;
            PlainText = text;
            RichText = richText;
            IsSelfMention = isSelfMention;
            Time = time;
        }

        public string PlainText { get; }
        public List<RichTextNode> RichText { get; }

        public string SenderName { get; }
        public string SenderTrip { get; }
        public bool IsSelfMention { get; }
        public DateTime Time { get; }
    }
}