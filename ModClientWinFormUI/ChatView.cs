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

        //the row where the next chat will be inserted
        private int nextRow;

//        private static Style UsernameStyle = new TextStyle(new SolidBrush(Color.DodgerBlue), null, FontStyle.Bold);
//        private static Style UsernameStyle = new ShortcutStyle(Pens.Black);
        private static Style usernameStyle = new UsernameStyle(new SolidBrush(Color.DarkCyan), null, FontStyle.Regular);
        private static Style latexStyle = new TextStyle(new SolidBrush(Color.LightBlue), null, FontStyle.Italic);
        private static Style tripStyle = new TextStyle(new SolidBrush(Color.Aqua), null, FontStyle.Italic);
        private static Style timeStyle = new TextStyle(new SolidBrush(Color.LightSeaGreen), null, FontStyle.Italic);

        public ChatView()
        {
            InitializeComponent();

            Service = new HackChatMessageService("whomst", "kek", "botDev");
            Service.OnMessageRecieved += AddMessage;

            usernameStyle.VisualMarkerClick +=
                (sender, args) =>
                {
                    messageInputBox.AppendText("@" + (usernameStyle as UsernameStyle)?.GetText(args.Marker));
                };
            //Service.SendMessage("hello");
        }

        public void AddMessage(ModClient.MessageService.Message message)
        {
            Invoke((MethodInvoker) (() =>
            {
                AppendStyle(message.Time.ToString("hh:mmtt"), timeStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderTrip, tripStyle);
                chatBox.AppendText(" ");
                AppendStyle(message.SenderName, usernameStyle);
                chatBox.AppendText(": ");

                foreach (var node in message.RichText)
                {
                    switch (node.Type)
                    {
                        case RichTextNode.NodeType.TEXT:
                            AppendStyle(node.Value, null);
                            break;
                        case RichTextNode.NodeType.FORMATTED:
                            AppendStyle(node.Value, latexStyle);
                            break;
                        case RichTextNode.NodeType.USERNAME:
                            AppendStyle(node.Value, usernameStyle);
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