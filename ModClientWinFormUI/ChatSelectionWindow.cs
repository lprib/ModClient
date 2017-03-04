using System;
using System.Windows.Forms;
using ModClient.MessageService;
using ModClient.MessageService.HackChat;
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