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
            Log("Error", "SOmething");
        }

        public static void Log(string statusType,  string message)
        {
            Logger log = Logger.Instance(statusType, message);
            Console.WriteLine(log);
        }
    }

    public class Logger
    {
        static Logger _instance;

        private Logger() { }

        private static readonly object _lock = new object();

        public static Logger Instance(string statusType, string message)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                        _instance.StatusType = statusType;
                        _instance.Message = message;
                    }
                }
            }
            return _instance;
        }
        public string StatusType { get; set; }
        public string Message { get; set; }
    }
}
