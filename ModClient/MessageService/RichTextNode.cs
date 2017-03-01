namespace ModClient.MessageService
{
    //Rich text is represented by a list of nodes, each with a type
    //these nodes can be interpreted by the frontend for formatting
    public class RichTextNode
    {
        public string Value { get; }
        public NodeType Type { get; }

        public enum NodeType
        {
            Text,
            Username,
            Formatted
        }

        public RichTextNode(string value, NodeType type)
        {
            Value = value;
            Type = type;
        }
    }
}