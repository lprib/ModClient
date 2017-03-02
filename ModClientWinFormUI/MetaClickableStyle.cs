using System;
using System.Collections.Generic;
using System.Drawing;
using FastColoredTextBoxNS;

namespace ModClientWinFormUI
{
    //this is a custom style that, when clicked, can return the text that was clicked.
    //retrieve this by using the GetText(marker), and pass in the VisualMarkerEvenArgs.Marker
    //this is supplied within the OnVisualMarkerClick event
    public class MetaClickableStyle : TextStyle
    {
        //the clicker cannot get the text, so it must be stored in a dictionary for retrieval
        private readonly Dictionary<StyleVisualMarker, string> strings;

        public MetaClickableStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle) : base(foreBrush, backgroundBrush, fontStyle)
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