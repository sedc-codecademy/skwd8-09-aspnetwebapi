using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared
{
    //appsettings.json -> AppSettings section
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string SecretKey { get; set; }
    }
}
