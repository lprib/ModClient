using System;
using System.Collections.Generic;
using ModClient.MessageServices;

namespace ModClient.Plugins
{
    public class Plugin
    {
        protected IServiceView View { get; }

        public Plugin(IServiceView view)
        {
            View = view;
        }
    }
}