using System;

namespace PineOS.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Info => "Show all Commands.";

        public void Execute(string[] args)
        {
            Core.ConsoleManager.WriteIn("Commands:");

            foreach (var cmd in CommandManager.GetAllCommands())
            {
                Core.ConsoleManager.WriteIn($"{cmd.Name}: {cmd.Info}");
            }
        }
    }
}
