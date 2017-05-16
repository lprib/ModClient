namespace ModClient.Plugins
{
    public delegate void OnConfigOptionChangedDelegate(object oldVal, object newVal);

    /* 
     * If the option has DataType of button, the Data field should be an int.
     * To say the button has been pressed, just increment the Data field.
     */

    public class ConfigOption
    {
        public enum Type
        {
            Boolean,
            Button,
            Text
        }

        private object data;

        public ConfigOption(string name, Type dataType, OnConfigOptionChangedDelegate onChangedAction = null)
        {
            Name = name;
            DataType = dataType;

            switch (DataType)
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

            if (onChangedAction != null)
                OnChanged += onChangedAction;
        }

        public string Name { get; }
        public Type DataType { get; }

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
    }
}