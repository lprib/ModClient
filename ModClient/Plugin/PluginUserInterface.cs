using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModClient.Plugin
{
    public delegate void OnConfigOptionChangedDelegate(object oldVal, object newVal);

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
                OnConfigChanged?.Invoke(data, value);
                data = value;
            }
        }

        public event OnConfigOptionChangedDelegate OnConfigChanged;

        public ConfigOption(string configName, Type configType)
        {
            ConfigName = configName;
            ConfigType = configType;
        }

        public enum Type
        {
            Boolean,
            Button,
            Text,
        }
    }
}