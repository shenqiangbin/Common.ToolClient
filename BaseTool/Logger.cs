using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"Log4net.config", Watch = true)]
namespace BaseTool
{

    public static class Logger
    {
        public static void Log(string msg)
        {
            ILog _log = LogManager.GetLogger("FileLogger");
            _log.Error(msg);
        }

        public static void Log(Exception ex)
        {
            ILog _log = LogManager.GetLogger("FileLogger");
            _log.Error(ex.Message + ex.StackTrace);
        }

    }

    //public class SqlLogger
    //{
    //    public static void Log(string msg)
    //    {
    //        ILog _log = LogManager.GetLogger("SysLogger");
    //        _log.Error(msg);
    //    }

    //    public static void Log(object msg)
    //    {
    //        ILog _log = LogManager.GetLogger("SysLogger");
    //        _log.Error(msg);
    //    }

    //    public static void Log(Exception ex)
    //    {
    //        ILog _log = LogManager.GetLogger("SysLogger");
    //        _log.Error(ex.Message + ex.StackTrace);
    //    }
    //}


}
