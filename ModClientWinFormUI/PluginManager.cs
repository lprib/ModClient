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
using ModClient.Plugins;
using ModClientWinFormUI.Properties;

namespace ModClientWinFormUI
{
    public partial class PluginManager : Form
    {
        private ServiceView service;

        public ServiceView Service
        {
            set
            {
                service = value;
                //when service is initially loaded, add the UI for each already running plugin
                foreach (var plugin in service.Plugins)
                {
                    InitialisePluginUI(plugin);
                }
            }
        }

        private Button currentSelectedPluginButton;

        private Dictionary<Button, Plugin> activePluginButtons = new Dictionary<Button, Plugin>();

        public PluginManager()
        {
            InitializeComponent();
            InitialiseNewPluginComboBox();

            Icon = Icon.FromHandle(Resources.script_lightning.GetHicon());
        }

        private void InitialiseNewPluginComboBox()
        {
            //add all the default plugins to the New Plugin DropDown
            foreach (var tuple in Plugin.DefaultPlugins)
            {
                newPluginComboBox.Items.Add(tuple.Item1);
            }

            //load up the UI and initialise the plugin when it is selected in the dropdown
            newPluginComboBox.SelectionChangeCommitted += (sender, args) =>
            {
                var selectedPluginTuple = Plugin.DefaultPlugins[newPluginComboBox.SelectedIndex];
                var plugin = (Plugin) Activator.CreateInstance(selectedPluginTuple.Item2, service);
                service.AddPlugin(plugin);
                InitialisePluginUI(plugin);
            };
        }

        private void InitialisePluginUI(Plugin plugin)
        {
            var activePluginButton = new Button
            {
                Text = plugin.ToString()
            };

            activePluginButtons[activePluginButton] = plugin;

            //when the active plugin is clicked in the list, load up its config options in the options panel
            activePluginButton.Click +=
                (sender, args) =>
                {
                    pluginOptionsPanel.Controls.Clear();
                    pluginOptionsPanel.Controls.Add(GetOptionsPanel(plugin));
                    currentSelectedPluginButton = activePluginButton;
                };

            activePluginsList.Controls.Add(activePluginButton);
        }

        private TableLayoutPanel GetOptionsPanel(Plugin plugin)
        {
            TableLayoutPanel panel = new TableLayoutPanel
            {
                GrowStyle = TableLayoutPanelGrowStyle.AddRows,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                //Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 50),
                    new ColumnStyle(SizeType.Percent, 50)
                },
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int configOptionIndex = 0; configOptionIndex < plugin.ConfigOptions.Count; configOptionIndex++)
            {
                var configOption = plugin.ConfigOptions[configOptionIndex];
                panel.Controls.Add(new Label {Text = configOption.Name}, 0, configOptionIndex);
                panel.Controls.Add(getControl(configOption), 1, configOptionIndex);
            }
            return panel;
        }

        private Control getControl(ConfigOption option)
        {
            Control control = null;
            switch (option.DataType)
            {
                case ConfigOption.Type.Boolean:
                    control = new CheckBox {Checked = (bool) option.Data};
                    control.Click += (s, a) => option.Data = ((CheckBox) control).Checked;
                    break;
                case ConfigOption.Type.Text:
                    control = new TextBox {Text = (string) option.Data, Dock = DockStyle.Fill};

                    //update the underlying control when enter is pressed
                    control.KeyPress += (s, keyArgs) =>
                    {
                        if (keyArgs.KeyChar == (char) Keys.Enter)
                        {
                            option.Data = ((TextBox) control).Text;
                            keyArgs.Handled = true;
                        }
                    };
                    break;
                case ConfigOption.Type.Button:
                    control = new Button {Text = option.Name, Dock = DockStyle.Fill};
                    //increment data on click as per spec
                    control.Click += (s, a) => option.Data = (int) option.Data + 1;
                    break;
            }
            return control;
        }

        private void removePluginButton_Click(object sender, EventArgs e)
        {
            var pluginToRemove = activePluginButtons[currentSelectedPluginButton];
            activePluginsList.Controls.Remove(currentSelectedPluginButton);
            service.RemovePlugin(pluginToRemove);
            pluginOptionsPanel.Controls.Clear();
        }
    }
}