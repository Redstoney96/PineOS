using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.FileSystem.VFS;
using System;
using System.IO;

namespace PineOS.Commands
{
    public class FileCommand : ICommand
    {
        public string Name => "file";
        public string Info => "A command to manage files";

        public void Execute(string[] args)
        {
            // --- Argumentprüfung ---
            if (args.Length == 0)
            {
                Core.ConsoleManager.WriteIn("Usage: file [list | read <filename>]");
                return;
            }

            string currentPath = Core.FileManager.GetPath();

            // --- LIST ---
            if (args[0] == "list")
            {
                // Dateien
                foreach (var file in Directory.GetFiles(currentPath))
                    Core.ConsoleManager.WriteIn("@" + Path.GetFileName(file));

                // Ordner
                foreach (var dir in Directory.GetDirectories(currentPath))
                    Core.ConsoleManager.WriteIn("#" + Path.GetFileName(dir));

                return;
            }

            // --- READ ---
            if (args[0] == "read")
            {
                if (args.Length < 2)
                {
                    Core.ConsoleManager.WriteIn("Usage: file read <filename>");
                    return;
                }

                string fullPath = Path.Combine(currentPath, args[1]);

                if (!File.Exists(fullPath))
                {
                    Core.ConsoleManager.WriteIn("File not found: " + args[1]);
                    return;
                }

                string content = File.ReadAllText(fullPath);

                Core.ConsoleManager.WriteIn("========== File Reader ==============");
                Core.ConsoleManager.WriteIn(content);
                Core.ConsoleManager.WriteIn("=====================================");

                return;
            }

            // --- Unbekannter Subcommand ---
            Core.ConsoleManager.WriteIn("Unknown subcommand: " + args[0]);
        }
    }
}
