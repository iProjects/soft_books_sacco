using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSacco
{
    public class SBSystem3
    {
        public string Name { get; set; }
        public string Application { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string AttachDB { get; set; }
        public string Metadata { get; set; }
        public string Version { get; set; }
        public bool Default { get; set; }

        public SBSystem3(string name, string app, string database, string server, string attach, string metadata, string ver, bool def)
        {
            this.Name = name;
            this.Application = app;
            this.Database = database;
            this.Server = server;
            this.AttachDB = attach;
            this.Metadata = metadata;
            this.Version = ver;
            this.Default = def;
        }
    }

    

}
