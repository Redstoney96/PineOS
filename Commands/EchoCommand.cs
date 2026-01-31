using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineOS.Commands
{
    public class EchoCommand : ICommand
    {
        public string Name => "echo";
        public string Info => "send text to the console";
        public void Execute(string[] args)
        {
            Console.WriteLine(string.Join(",", args));
        }
    }
}
