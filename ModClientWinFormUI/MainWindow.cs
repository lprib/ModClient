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
using ModClientWinFormUI.Properties;

namespace ModClientWinFormUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //load icon from resources
            Icon = Icon.FromHandle(Resources.icon.GetHicon());
        }

        private void AddTab(MessageServiceBase serviceBase)
        {
            var newTab = new TabPage()
            {
                Controls = {new ChatView() {Dock = DockStyle.Fill, ServiceBase = serviceBase}},
                Text = serviceBase.Username + "@" + serviceBase.Channel
            };
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void addTab_Click(object sender, EventArgs e)
        {
            var selectionWin = new ChatSelectionWindow();
            selectionWin.ShowDialog();
            if (selectionWin.DialogResult == DialogResult.OK)
            {
                AddTab(new HackChatMessageServiceBase(selectionWin.Username, selectionWin.Password, selectionWin.Channel));
            }
        }

        private void closeTabButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl1.SelectedTab;
            if (selected == null) return;

            foreach (var control in selected.Controls)
            {
                (control as ChatView)?.ServiceBase.Close();
            }

            tabControl1.TabPages.Remove(selected);
        }

        //close all services on main form close
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var page in tabControl1.TabPages)
            foreach (var control in ((TabPage) page).Controls)
                (control as ChatView)?.ServiceBase.Close();
        }

        private void devChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new HackChatMessageServiceBase("ModClient_test", "test", "botDev"));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/JaxForReal/ModClient/");
        }
    }
}