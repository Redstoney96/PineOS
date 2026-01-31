using PineOS.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using Sys = Cosmos.System;

namespace PineOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            CommandManager.Register(new EchoCommand());
            CommandManager.Register(new FileCommand());
            CommandManager.Register(new HelpCommand());
            CommandManager.Register(new SystemCommand());
            CommandManager.Register(new TimeCommand());
            Boot();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PineOS booted successfully.");
            Home();
        }

        protected override void Run()
        {
            Console.Write(">");
            var input = Console.ReadLine();
            CommandManager.Execute(input);
        }
        private void Home()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("|=============================|");
            Console.WriteLine("|============PineOS===========|");
            Console.WriteLine("|=============================|");
            Console.BackgroundColor = ConsoleColor.Green;
        }
        private void Boot()
        {
            Console.WriteLine("Loading Storage");
            var storage = fs.GetVolumes();
            Console.WriteLine("Load Volume: " + storage);
            var type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("Volume Type: " + type);
            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Available Free Space: " + available_space);
            var files = Directory.GetFiles(@"0:\");
            Console.WriteLine("Files in Volume 0:");
            foreach (var file in files)
            {
                Console.WriteLine("#" +  file);
            }
            Console.WriteLine("Loading......");
            WaitSeconds(5);
            Console.Clear();
        }
        public static void WaitSeconds(int seconds)
        {
            var target = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < target)
            {

            }
        }
    }
}
