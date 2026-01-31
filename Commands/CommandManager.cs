using System;
using System.Collections.Generic;

namespace PineOS.Commands
{
    public static class CommandManager
    {
        private static Dictionary<string, ICommand> commands = new();

        public static void Register(ICommand command)
        {
            commands[command.Name] = command;
        }

        public static void Execute(string input)
        {
            var parts = input.Split(' ');
            var name = parts[0];
            string[] args;
            if (parts.Length > 1)
            {
                args = new string[parts.Length - 1];
                for (int i = 1; i < parts.Length; i++)
                    args[i - 1] = parts[i];
            }
            else
            {
                args = Array.Empty<string>();
            }


            if (commands.ContainsKey(name))
            {
                commands[name].Execute(args);
            }
            else
            {
                Core.ConsoleManager.WriteIn($"Unkown Command: {name}");
            }
        }

        public static IEnumerable<ICommand> GetAllCommands()
        {
            return commands.Values;
        }
    }
}
