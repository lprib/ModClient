using System;
using System.Windows.Forms;
using ModClient.MessageService;
using ModClient.MessageService.Chatto;
using ModClient.MessageService.HackChat;
using ModClient.MessageService.Irc;
using ModClient.MessageService.ToastyChat;

namespace ModClientWinFormUI
{
    public partial class ChatSelectionWindow : Form
    {
        public ChatSelectionWindow()
        {
            InitializeComponent();
//            serverTextBox.DataBindings.Add("Text", this, "Server");
//            channelTextBox.DataBindings.Add("Text", this, "Channel");
//            usernameTextBox.DataBindings.Add("Text", this, "Username");
//            passwordTextBox.DataBindings.Add("Text", this, "Password");
        }

        public MessageServiceBase MessageService { get; private set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
            switch ((string) connectionTypeCombo.SelectedItem)
            {
                case "Hack.chat":
                    MessageService = new HackChatMessageService(usernameTextBox.Text, passwordTextBox.Text,
                        channelTextBox.Text);
                    break;
                case "Toasty.chat":
                    MessageService = new ToastyChatMessageService(usernameTextBox.Text, passwordTextBox.Text,
                        channelTextBox.Text);
                    break;
                case "IRC":
                    MessageService = new IrcMessageService(serverTextBox.Text, channelTextBox.Text, usernameTextBox.Text, passwordTextBox.Text);
                    break;
                case "Chatto":
                    MessageService = new ChattoMessageService(serverTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, channelTextBox.Text);
                    break;
            }
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}