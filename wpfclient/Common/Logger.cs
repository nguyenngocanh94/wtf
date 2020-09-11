using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfclient.Common
{
    public static class Logger
    {
        public static Func<log4net.ILog> GetLog;
    }
}
