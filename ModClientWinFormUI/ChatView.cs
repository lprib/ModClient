using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using ModClient.MessageService;
using ModClient.MessageService.HackChat;
using ModClientWinFormUI.Properties;

namespace ModClientWinFormUI
{
    public partial class ChatView : UserControl
    {
        private MessageServiceBase service;

        [Browsable(false)]
        public MessageServiceBase Service
        {
            get { return service; }
            set
            {
                service = value;
                if (value == null)
                    throw new NullReferenceException();
                Service.OnMessageRecieved += AddMessage;
                Service.OnInfoRecieved += AddInfo;
                Service.OnPluginOutput += output => AppendStyle(output + "\n", PluginOutputStyle);
            }
        }

        private static readonly Style UsernameStyle =
            new UsernameStyle(new SolidBrush(Color.FromArgb(33, 150, 243)), null, FontStyle.Bold);

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

        public ChatView()
        {
            InitializeComponent();

            UsernameStyle.VisualMarkerClick +=
                (sender, args) =>
                {
                    messageInputBox.AppendText("@" + (UsernameStyle as UsernameStyle)?.GetText(args.Marker) + " ");
                    messageInputBox.Select();
                };
            chatBox.AppendText("\n");
        }

        public void AddMessage(ModClient.MessageService.Message message)
        {
            Invoke((MethodInvoker) (() =>
            {
                AppendStyle("--", SelfMentionStyle);
                AppendStyle(message.Time.ToString("hh:mmtt"), TimeStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderTrip, TripStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderName, UsernameStyle);
                chatBox.AppendText(": ");

                //if multiline message, make every line on its own line
                if (message.PlainText.Contains("\n"))
                    chatBox.AppendText("\n");

                foreach (var node in message.RichText)
                {
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
                }

                chatBox.AppendText("\n");
            }));
        }

        private void AddInfo(InfoType type, object data)
        {
            switch (type)
            {
                case InfoType.OnlineSet:
                    AppendStyle("Online users: " + ((List<string>) data).Aggregate((a, i) => a + ", " + i) + "\n",
                        InfoStyle);
                    break;
                case InfoType.OnlineAdd:
                    AppendStyle(((string) data) + " joined.\n", InfoStyle);
                    break;
                case InfoType.OnlineRemove:
                    AppendStyle(((string) data) + " left.\n", InfoStyle);
                    break;
                default:
                    AppendStyle(type + "\n", InfoStyle);
                    break;
            }
        }

        private void messageInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                Service.SendMessage(messageInputBox.Text);
                messageInputBox.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void AppendStyle(string text, Style style)
        {
            chatBox.AppendText(text);

            if (style == null || text == null) return;
            var appendRange = chatBox.GetRange(chatBox.TextLength - text.Length - 1, chatBox.TextLength);
            appendRange.SetStyle(style);
        }

        //used when the tab is closed
        public void Close()
        {
            Service.Close();
        }
    }
}