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
using ModClient.Plugin;

namespace ModClientWinFormUI
{
    public partial class PluginManager : Form
    {
        private MessageServiceBase service;
        private int currentOptionTableRow = 0;

        public MessageServiceBase Service
        {
            get { return service; }
            set
            {
                service = value;
                foreach (var plugin in service.Plugins)
                    addPluginToList(plugin);
            }
        }

        public PluginManager()
        {
            InitializeComponent();
            foreach (var defaultPluginTuple in DefaultSettings.DefaultPlugins)
            {
                addPluginSelect.Items.Add(defaultPluginTuple.Item1);
                addPluginSelect.SelectedIndexChanged +=
                    (sender, args) =>
                    {
                        var newPlugin =
                            (PluginBase)
                            Activator.CreateInstance(
                                typeof(ConfigOptionsTest),
                                service);
                        service.AddPlugin(newPlugin);
                        addPluginToList(newPlugin);
                    };
            }
        }

        private void addPluginToList(PluginBase plugin)
        {
            var newPluginButton = new Button {Text = plugin.ToString()};
            pluginListView.Controls.Add(newPluginButton);
            //when the plugin is clicked in the list, its options should come up
            newPluginButton.Click += (sender, args) =>
            {
                resetPluginOptions();
                foreach (var option in plugin.GetConfigOptions())
                {
                    addPluginOption(option);
                }
            };
        }

        private void addPluginOption(ConfigOption option)
        {
            pluginOptions.Controls.Add(new Label {Text = option.ConfigName}, 0, currentOptionTableRow);
            switch (option.ConfigType)
            {
                case ConfigOption.Type.Boolean:
                    pluginOptions.Controls.Add(new CheckBox(), 1, currentOptionTableRow);
                    break;
                case ConfigOption.Type.Text:
                    pluginOptions.Controls.Add(new TextBox(), 1, currentOptionTableRow);
                    break;
                case ConfigOption.Type.Button:
                    pluginOptions.Controls.Add(new Button(), 1, currentOptionTableRow);
                    break;
            }
            currentOptionTableRow++;
        }

        private void resetPluginOptions()
        {
            pluginOptions.Controls.Clear();
            currentOptionTableRow = 0;
        }

        private void saveOptionsButton_Click(object sender, EventArgs e)
        {
        }
    }
}