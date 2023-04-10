using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract internal class Logger              // Логгер для выведения исключений
    {
        static public void LogException(Exception exc)
        {
            var type = exc.GetType();
            var message = exc.Message;
            var stackTrace = exc.StackTrace;

            Console.WriteLine("An Exceprion occurred:");
            Console.WriteLine("\tType: " + type);
            Console.WriteLine("\tMessage: " + message);
            Console.WriteLine("\tStackTrace:\n" + stackTrace);
        }
    }
}
