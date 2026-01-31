using Cosmos.Core;
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineOS.Commands
{
    public class SystemCommand : ICommand
    {
        public string Name => "system";
        public string Info => "A command to control the system";
        public void Execute(string[] args)
        {
            ACPI.Enable();
            if (args.Length < 0)
            {
                Core.ConsoleManager.WriteIn("Please enter a parameter");
            }
            if (args[0] == "shutdown")
            {
                Core.ConsoleManager.WriteIn("The system is shuting down");
                Power.ACPIShutdown();
            }
            if (args[0] == "reboot")
            {
                Core.ConsoleManager.WriteIn("The system is rebooting");
                Power.ACPIReboot();
            }
            if (args[0] == "reboot-save")
            {
                Core.ConsoleManager.WriteIn("The system is rebooting");
                Power.CPUReboot();
            }
        }
    }
}
