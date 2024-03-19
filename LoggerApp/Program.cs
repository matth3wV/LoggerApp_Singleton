using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger e1 = Logger.GetLogger();
        }
    }

    public class Logger
    {
        static Logger _instance;

        private Logger() { }

        private static readonly object _lock = new object();

        public static Logger Instance(string statusType, string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                        _instance.StatusType = statusType;
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
        public string StatusType { get; set; }
        public string Value { get; set; }
    }
}
