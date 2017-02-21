using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModClientUI
{
    /// <summary>
    /// Interaction logic for UsernameDisplay.xaml
    /// </summary>
    public partial class UsernameDisplay : UserControl
    {
        public UsernameDisplay(string username, string trip)
        {
            InitializeComponent();
            usernameText.Text = username;
            tripcodeText.Text = trip;
            usernameText.Foreground = new SolidColorBrush(GetHashedColor(username));
        }

        private void OnMouseEnter(object sender, MouseEventArgs e) => tripcodeText.Visibility = Visibility.Visible;

        private void OnMouseLeave(object sender, MouseEventArgs e) => tripcodeText.Visibility = Visibility.Collapsed;

        private Color GetHashedColor(string text)
        {
            int hash = text.GetHashCode();
            hash ^= 1795953092;

            /*
            Shift hash to get a certain byte in the rightmost spot.
            AND with 0xFF to ensure the byte is positive.
            Cast to (byte) to truncate it (will be in range 0 - 255)
            This ensures the colors are darker
            */
            var r = (byte)((hash >> 24) & 0xFF);
            var g = (byte)((hash >> 16) & 0xFF);
            var b = (byte)((hash >> 8) & 0xFF);
            return Color.FromRgb(r, g, b);
        }
    }
}
