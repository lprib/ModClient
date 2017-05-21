using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using ModClient.MessageServices;
using ModClient.Plugins;
using Message = ModClient.MessageServices.Message;

namespace ModClientWinFormUI
{
    public partial class ChatView : UserControl
    {
        private static readonly Style UsernameStyle =
            new MetaClickableStyle(new SolidBrush(Color.FromArgb(33, 150, 243)), null, FontStyle.Bold);

        private static readonly Style LatexStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(255, 152, 0)), null, FontStyle.Regular);

        private static readonly Style TripStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(96, 125, 139)), null, FontStyle.Regular);

        private static readonly Style TimeStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(38, 50, 56)), null, FontStyle.Regular);

        private static readonly Style InfoStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(76, 175, 80)), null, FontStyle.Italic);

        private static readonly Style SelfMentionStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(244, 67, 54)), null, FontStyle.Regular);

        private static readonly Style PluginOutputStyle =
            new TextStyle(new SolidBrush(Color.FromArgb(103, 58, 183)), null, FontStyle.Regular);

        private static readonly Style UrlStyle =
            new MetaClickableStyle(new SolidBrush(Color.FromArgb(236, 64, 122)), null, FontStyle.Regular);

        public MessageService.Plugin ViewPlugin { get; private set; }

        //TODO
        private List<string> lastSent = new List<string>();
        private int lastSentIndex;

        public ChatView()
        {
            InitializeComponent();

            UsernameStyle.VisualMarkerClick +=
                (sender, args) =>
                {
                    messageInputBox.AppendText("@" + ((MetaClickableStyle) UsernameStyle).GetText(args.Marker) + " ");
                    messageInputBox.Select();
                };

            //open urls on click
            UrlStyle.VisualMarkerClick +=
                (sender, args) => { Process.Start(((MetaClickableStyle) UrlStyle).GetText(args.Marker)); };
        }

        public MessageService Service
        {
            set
            {
                ViewPlugin = new ChatViewPlugin(value, this);
            }
        }

        public void AddMessage(Message message)
        {
            Invoke((MethodInvoker) (() =>
            {
                chatBox.AppendText("\n");

                AppendStyle("--", SelfMentionStyle);
                AppendStyle(message.Time.ToString("hh:mmtt"), TimeStyle);
                AppendStyle(" ");
                AppendStyle(message.SenderTrip, TripStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderName, UsernameStyle);
                chatBox.AppendText(": ");

                //if multiline message, make every line on its own line
                if (message.PlainText.Contains("\n"))
                    chatBox.AppendText("\n");

                foreach (var node in message.RichText)
                    switch (node.Type)
                    {
                        case RichTextNode.NodeType.Text:
                            AppendStyle(node.Value, message.IsSelfMention ? SelfMentionStyle : null);
                            break;
                        case RichTextNode.NodeType.Formatted:
                            AppendStyle(node.Value, LatexStyle);
                            break;
                        case RichTextNode.NodeType.Username:
                            AppendStyle(node.Value, UsernameStyle);
                            break;
                    }
            }));
        }

        private void AddInfo(InfoType type, object data)
        {
            AppendStyle("\n");
            switch (type)
            {
                case InfoType.OnlineSet:
                    AppendStyle("Online users: " + ((List<string>) data).Aggregate((a, i) => a + ", " + i),
                        InfoStyle);
                    break;
                case InfoType.OnlineAdd:
                    AppendStyle((string) data + " joined.", InfoStyle);
                    break;
                case InfoType.OnlineRemove:
                    AppendStyle((string) data + " left.", InfoStyle);
                    break;
                default:
                    AppendStyle(type + "", InfoStyle);
                    break;
            }
        }

        private void messageInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                ViewPlugin.SendMessage(messageInputBox.Text);
                messageInputBox.Clear();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
            }
        }

        //TODO null is getting passed in here as text at some point...
        private void AppendStyle(string text, Style style = null)
        {
            chatBox.AppendText(text);

            style = style ?? chatBox.DefaultStyle;
            text = text ?? "";

            var appendRange = chatBox.GetRange(chatBox.TextLength - text.Length, chatBox.TextLength);
            appendRange.SetStyle(style);
            appendRange.SetStyle(UrlStyle, @"http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?");
        }

        //used when the tab is closed
        public void Close()
        {
            ViewPlugin.Close();
        }

        private class ChatViewPlugin : MessageService.Plugin
        {
            private readonly ChatView parentChatView;

            public ChatViewPlugin(MessageService service, ChatView parentChatView) : base(service)
            {
                this.parentChatView = parentChatView;
            }

            public override void OnMessage(Message message) => parentChatView.AddMessage(message);

            public override void OnInfo(InfoType type, object data) => parentChatView.AddInfo(type, data);

            public override void OnLocalOutput(string output)
                => parentChatView.AppendStyle("\n" + output, PluginOutputStyle);

            public override string PluginName { get; } = "UI";
        }
    }
}