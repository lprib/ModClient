using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModClientWinFormUI
{
    public partial class Username : UserControl
    {
        public string Name
        {
            get { return Name; }
            set
            {
                usernameDisplay.Text = value;
                Name = value;
            }
        }

        public string Trip
        {
            get { return Trip; }
            set
            {
                tripDisplay.Text = value;
                Trip = value;
            }
        }

        public Username()
        {
            InitializeComponent();
            usernameDisplay.ForeColor = GetHashColor(username);
        }

        public Color GetHashColor(string str)
        {
            var hash = str.GetHashCode();

            //maybe randomly distribute?
            hash ^= 2015984357;

            var r = (byte) (hash >> 24) & 0xFF;
            var g = (byte) (hash >> 16) & 0xFF;
            var b = (byte) (hash >> 8) & 0xFF;
            return Color.FromArgb(r, g, b);
        }
    }
}