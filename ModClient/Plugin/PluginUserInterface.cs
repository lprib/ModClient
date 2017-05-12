using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModClient.Plugin
{
    public delegate void OnConfigOptionChangedDelegate(object oldVal, object newVal);

    /*If the option has ConfigType of button, the Data field should be an int. To say the button has been pressed, just increment the Data field.
     * 
     */

    public class ConfigOption
    {
        public string ConfigName { get; }
        public Type ConfigType { get; }

        private object data;

        public object Data
        {
            get { return data; }
            set
            {
                OnChanged?.Invoke(data, value);
                data = value;
            }
        }

        public event OnConfigOptionChangedDelegate OnChanged;

        public ConfigOption(string configName, Type configType)
        {
            ConfigName = configName;
            ConfigType = configType;

            switch (ConfigType)
            {
                case Type.Boolean:
                    Data = false;
                    break;
                case Type.Button:
                    Data = 0;
                    break;
                case Type.Text:
                    Data = "";
                    break;
            }
        }

        public enum Type
        {
            Boolean,
            Button,
            Text,
        }
    }
}