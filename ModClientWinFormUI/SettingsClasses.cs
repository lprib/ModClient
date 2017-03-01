using System;
using System.Collections.Generic;

namespace ModClientWinFormUI
{
    [Serializable]
    public class Connection
    {
        public string Server { get; set; }
        public string Channel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Serializable]
    public class SavedConnectionsList : List<Connection>
    {
    }
}