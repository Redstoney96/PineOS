using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineOS.Commands
{
    public class TimeCommand : ICommand
    {
        public string Name => "time";
        public string Info => "show the curent time and date";
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Core.ConsoleManager.WriteIn("time or date?");
            }
            if (args[0] == "time")
            {
                Core.ConsoleManager.WriteIn(DateTime.Now.ToShortTimeString());
            }
            if (args[0] == "date")
            {
                Core.ConsoleManager.WriteIn(DateTime.Now.ToShortDateString());
            }
        }
    }
}
