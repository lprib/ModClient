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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void defaultStartButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
