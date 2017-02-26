using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModClientWinFormUI
{
    public partial class ChatSelectionWindow : Form
    {
        public string Channel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ChatSelectionWindow()
        {
            InitializeComponent();
            channelTextBox.DataBindings.Add("Text", this, "Channel");
            usernameCheckBox.DataBindings.Add("Text", this, "Username");
            passwordCheckBox.DataBindings.Add("Text", this, "Password");
        }

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
