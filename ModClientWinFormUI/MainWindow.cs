using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModClient.MessageService;
using ModClient.MessageService.HackChat;

namespace ModClientWinFormUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void defaultStartButton_Click(object sender, EventArgs e)
        {
            AddTab(new HackChatMessageService("start", "asd", "botDev"));
        }

        private void AddTab(IMessageService service)
        {
            var newTab = new TabPage()
            {
                Controls = {new ChatView() {Dock = DockStyle.Fill, Service = service}},
                Text = service.Username + "@" + service.Channel
            };
            tabControl1.TabPages.Add(newTab);
        }

        private void closeTabButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl1.SelectedTab;

            foreach (var control in selected.Controls)
            {
                (control as ChatView)?.Service.Close();
            }

            tabControl1.TabPages.Remove(selected);
        }
    }
}