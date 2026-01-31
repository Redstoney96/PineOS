using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineOS.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Info { get; }
        void Execute(string[] args);
    }
}
