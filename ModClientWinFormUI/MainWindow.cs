using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ModClient.MessageServices;
using ModClient.MessageServices.HackChat;
using ModClient.Plugins;
using ModClient.Plugins.DefaultPlugins;
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

        private void AddTab(MessageService service)
        {
            var newTab = new TabPage
            {
                Controls = {new ChatView {Dock = DockStyle.Fill, Service = service}},
                Text = service.Username + "@" + service.Channel
            };
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void addTab_Click(object sender, EventArgs e)
        {
            var selectionWin = new ChatSelectionWindow();
            selectionWin.ShowDialog();
            if (selectionWin.DialogResult == DialogResult.OK)
                AddTab(selectionWin.MessageService);
        }

        private void closeTabButton_Click(object sender, EventArgs e)
        {
            var selected = tabControl1.SelectedTab;
            if (selected == null) return;

            foreach (var control in selected.Controls)
                (control as ChatView)?.ViewPlugin.Close();

            tabControl1.TabPages.Remove(selected);
        }

        //close all services on main form close
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var page in tabControl1.TabPages)
            foreach (var control in ((TabPage) page).Controls.OfType<ChatView>())
                control.ViewPlugin.Close();
        }

        private void devChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(new HackChatMessageService("ModClient_test", "test", "botDev"));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://github.com/JaxForReal/ModClient/");
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = tabControl1.SelectedTab.Controls.OfType<ChatView>().FirstOrDefault()?.ViewPlugin;
            if (service == null)
            {
                MessageBox.Show("No ViewPlugin running in the current tab.", "Cannot open Plugin Manager", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            var pluginManager = new PluginManager
            {
                ViewPlugin = service
            };
            pluginManager.Show();
        }
    }
}