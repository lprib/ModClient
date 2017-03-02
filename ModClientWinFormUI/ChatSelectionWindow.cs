using System;
using System.Windows.Forms;

namespace ModClientWinFormUI
{
    public partial class ChatSelectionWindow : Form
    {
        public ChatSelectionWindow()
        {
            InitializeComponent();
            serverTextBox.DataBindings.Add("Text", this, "Server");
            channelTextBox.DataBindings.Add("Text", this, "Channel");
            usernameCheckBox.DataBindings.Add("Text", this, "Username");
            passwordCheckBox.DataBindings.Add("Text", this, "Password");
        }

        public string Server { get; set; }
        public string Channel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}