using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions.Utils
{

    public interface Ilogger
    {
        public void Info(string message);        
        public void Debug(string message);

        public void Error(string message);
        public void Perf(string message);
    }
    public class Logger : Ilogger
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}] [INFO] {message}");
        }

        public void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{DateTime.Now}] [DEBUG] {message}");
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now}] [ERROR] {message}");
        }

        public void Perf(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{DateTime.Now}] [PERF] {message}");
        }
    }
}