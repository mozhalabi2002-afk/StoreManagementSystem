using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class ClsSettings
    {
        public static string SourceName
        {

            get
            {
                string Name = "Store";

                if (EventLog.Exists(Name))
                {
                    EventLog.CreateEventSource(Name, "Application");
                }
                return Name;
            }

        }
    }
}
