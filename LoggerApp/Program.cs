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
            logType Comment = new logType("Comment","white");
            logType Warning = new logType("Warning","yellow");
            logType Error = new logType("Error","red");

            Log(Warning, "issue to be wary of");
            Log(Comment, "interesting fact");
            Log(Error, "divide by zero");
            
            Console.ReadKey();
        }

        public static void Log(logType statusType,  string message)
        {

            Logger log = Logger.Instance(statusType, message);
            Console.WriteLine(log.StatusType.Name + ": " + log.Message );

        }
    }

    public class logType
    {
        public logType(string name, string fontColor) 
        {
            Name =  name;
            FontColor = fontColor;
        }
        public string Name { get;  set; }
        public string FontColor { get;  set; }

      
        
    }
    public class Logger
    {
        static Logger _instance;

        private Logger() { }

        private static readonly object _lock = new object();

        public static Logger Instance(logType statusType, string message)
        {
            if (_instance == null )
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
        public logType StatusType { get; set; }
        public string Message { get; set; }
    }
}
