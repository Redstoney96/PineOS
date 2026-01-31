using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PineOS.Core
{
    public static class ConsoleManager
    {
        public static void WriteIn(string text)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("@" + text);
            Console.BackgroundColor = ConsoleColor.Green;
        }

    }
}
