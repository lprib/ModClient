using System.Collections.Generic;
using System.Text.RegularExpressions;
using ModClient.MessageService;
using System.Linq;
using System;

namespace ModClient.MessageService.HackChat
{
    //statically Parses an incoming message string into a list of RichTextNodes.
    static class HackChatTextParser
    {
        private static Regex latex = new Regex(@"\$[^\$]*\$");

        public static List<RichTextNode> GetRichText(string text, IMessageService service)
        {
            //start with a single plaintext node conatining the entire text
            var richText = new List<RichTextNode>();
            richText.Add(new RichTextNode(text, RichTextNode.NodeType.TEXT));

            //chunkify using the results of a regexp match
            Chunkify(
                richText,
                GetChunkifyMatcher(latex),
                RichTextNode.NodeType.FORMATTED
            );

            Chunkify(
                richText,
                str =>
                {
                    var slices = new List<StringSlice>();
                    //the index where the last username was found in the string
                    //only searches after this index, so that overlapping usernames are not found
                    var nextSearchStart = 0;

                    //order usernames from long length to short. This means that smaller usernames embedded in larger ones are not detected
                    //eg @hi will no get detected if the string is "@hiClient"
                    foreach (var username in service.OnlineUsers.OrderByDescending(s => s.Length))
                    {
                        var index = str.IndexOf(username, nextSearchStart, StringComparison.OrdinalIgnoreCase);
                        if (index != -1)
                        {
                            slices.Add(new StringSlice(index, username.Length));
                            nextSearchStart = index + username.Length;
                        }
                    }
                    return slices;
                },
                RichTextNode.NodeType.USERNAME
            );

            return richText;
        }

        //takes a list of textNodes, and looks at each node which has type Text ie. not already formatted
        //for each text node, uses the supplied `matcher` func to determine which slices need to be formatted into nodetype of `newNodeType`
        //converts the text node into a series of textNodes, and formatted nodes (inserting back into the supplied list)

        //eg {Text1, Formatted, Text2} where Text2 contains a username might get converted to:
        //{Text1, Formatted, Text, Username, Text}
        private static void Chunkify(List<RichTextNode> startingList, Func<string, List<StringSlice>> matcher,
            RichTextNode.NodeType newNodeType)
        {
            var textNodes = startingList.Where(node => (node.Type == RichTextNode.NodeType.TEXT)).ToList();
            //examine each plaintext node
            for (int iter = textNodes.Count - 1; iter >= 0; iter--)
            {
                var textNode = textNodes[iter];

                var matches = matcher(textNode.Value);

                //the index to insert the newly calculated nodes in the full richText
                var insertIndex = startingList.IndexOf(textNode);
                startingList.Remove(textNode);


                var insertList = new List<RichTextNode>();
                var lastSliceEnd = 0;

                foreach (var slice in matches)
                {
                    //surrounding plaintext
                    insertList.Add(new RichTextNode(textNode.Value.Substring(lastSliceEnd, slice.index - lastSliceEnd),
                        RichTextNode.NodeType.TEXT));
                    //formatted text node
                    insertList.Add(new RichTextNode(textNode.Value.Substring(slice.index, slice.length), newNodeType));
                    lastSliceEnd = slice.index + slice.length;
                }
                //end padding text node
                insertList.Add(new RichTextNode(textNode.Value.Substring(lastSliceEnd), RichTextNode.NodeType.TEXT));

                //insert back into original list
                startingList.InsertRange(insertIndex, insertList);
            }
        }

        private static Func<string, List<StringSlice>> GetChunkifyMatcher(Regex regex) =>
            str =>
                latex.Matches(str)
                    .Cast<Match>()
                    .Select(match => new StringSlice(match.Index, match.Length))
                    .Where(slice => slice.length > 0)
                    .ToList();

        // represends a slice of a string
        // used internally here to represend the slice of a string that contains latex or a username
        private struct StringSlice
        {
            public readonly int index;
            public readonly int length;

            public StringSlice(int index, int length)
            {
                this.index = index;
                this.length = length;
            }
        }
    }
}