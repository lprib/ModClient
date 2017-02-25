using System;
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

namespace ModClientWinFormUI
{
    public partial class ChatView : UserControl
    {
        private IMessageService service;

        [Browsable(false)]
        public IMessageService Service
        {
            get { return service; }
            set
            {
                service = value;
                if (value == null)
                    throw new NullReferenceException();
            }
        }

        private static readonly Style UsernameStyle = new UsernameStyle(new SolidBrush(Color.DarkCyan), null, FontStyle.Regular);
        private static readonly Style LatexStyle = new TextStyle(new SolidBrush(Color.LightBlue), null, FontStyle.Italic);
        private static readonly Style TripStyle = new TextStyle(new SolidBrush(Color.Aqua), null, FontStyle.Italic);
        private static readonly Style TimeStyle = new TextStyle(new SolidBrush(Color.LightSeaGreen), null, FontStyle.Italic);

        public ChatView()
        {
            InitializeComponent();

            Service = new HackChatMessageService("dontRateLimit", "kek", "botDev");
            Service.OnMessageRecieved += AddMessage;

            UsernameStyle.VisualMarkerClick +=
                (sender, args) =>
                {
                    messageInputBox.AppendText("@" + (UsernameStyle as UsernameStyle)?.GetText(args.Marker));
                };
        }

        public void AddMessage(ModClient.MessageService.Message message)
        {
            Invoke((MethodInvoker) (() =>
            {
                AppendStyle(message.Time.ToString("hh:mmtt"), TimeStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderTrip, TripStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderName, UsernameStyle);
                chatBox.AppendText(": ");

                foreach (var node in message.RichText)
                {
                    switch (node.Type)
                    {
                        case RichTextNode.NodeType.TEXT:
                            AppendStyle(node.Value, null);
                            break;
                        case RichTextNode.NodeType.FORMATTED:
                            AppendStyle(node.Value, LatexStyle);
                            break;
                        case RichTextNode.NodeType.USERNAME:
                            AppendStyle(node.Value, UsernameStyle);
                            break;
                    }
                }

                chatBox.AppendText("\n");
            }));
        }

        private void messageInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Service.SendMessage(messageInputBox.Text);
                messageInputBox.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void AppendStyle(string text, Style style)
        {
            chatBox.AppendText(text);

            if (style == null) return;
            var appendRange = chatBox.GetRange(chatBox.TextLength - text.Length, chatBox.TextLength);
            appendRange.SetStyle(style);
        }

        //used when the tab is closed
        public void Close()
        {
            Service.Close();
        }
    }
}