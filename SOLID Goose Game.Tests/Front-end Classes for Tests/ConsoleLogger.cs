using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void LogEmptyLine()
        {
            Console.WriteLine();
        }
        public void ClearLogger()
        {
            Console.Clear();
        }
    }
}
