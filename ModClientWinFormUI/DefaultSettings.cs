﻿using System;
using System.Collections.Generic;
using ModClient.Plugin;

namespace ModClientWinFormUI
{
    //this is a sane alternative to Winforms application settings, because you can use generics and custom types here,
    //without writing TypeConverters for everything

    //use this class for default lists of backends and plugin types
    public static class DefaultSettings
    {
        public static List<Tuple<string, Type>> DefaultPlugins = new List<Tuple<string, Type>>
        {
            Tuple.Create("Bibba", typeof(BibbaPlugin)),
            Tuple.Create("Text Corrector", typeof(TextCorrectionPlugin)),
            Tuple.Create("Automatic Response", typeof(ResponsePlugin))
        };
    }
}