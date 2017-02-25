using System;
using System.Collections.Generic;
using System.Drawing;
using FastColoredTextBoxNS;

namespace ModClientWinFormUI
{
    //this is a custom style for all usernames that allows clicking, and retrieving of the text that was clicked
    public class UsernameStyle : TextStyle
    {
        //the clicker cannot get the text, so it must be stored in a dictionary for retrieval
        private Dictionary<StyleVisualMarker, string> strings;

        public UsernameStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle) : base(foreBrush, backgroundBrush, fontStyle)
        {
            strings = new Dictionary<StyleVisualMarker, string>();
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            base.Draw(gr, position, range);

            var textBox = range.tb;
            //top left
            var startPoint = textBox.PlaceToPoint(range.Start);

            //bottom right
            var endPoint = textBox.PlaceToPoint(range.End);
            endPoint.Y += textBox.CharHeight;
            endPoint.X += textBox.CharWidth;

            var rect = new Rectangle(startPoint, new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
            var marker = new StyleVisualMarker(rect, this);
            //add marker to dictionary, so the text can be retrieved later
            strings[marker] = range.Text;

            AddVisualMarker(range.tb, marker);
        }

        public string GetText(StyleVisualMarker marker) => strings[marker];
    }
}