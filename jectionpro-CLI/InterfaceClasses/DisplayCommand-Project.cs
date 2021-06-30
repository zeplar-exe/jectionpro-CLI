using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class DisplayCommand_Project
    {
        public static Command GetCommand()
        {
            var command = new Command("display", "Lists all projects under a directory. [not implemented]")
            {
                new Option("-root", "Start searching from the root directory (i.e C:, D:)"),
            };

            command.Handler = CommandHandler.Create<bool, bool>(Handler);
            
            return command;
        }

        private static void Handler(bool root, bool silent)
        {
            Console.WriteLine(ParsingErrorResources.CommandNotImplemented);
            return; // TODO: Figure out why this hangs
            
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            if (root)
                directory = directory.Root;

            var pathList = new StringBuilder();
            
            Console.WriteLine(OtherMessagesResources.ResultsOmitted);
            pathList.AppendLine();

            foreach (var file in 
                SafeFileEnumerator.EnumerateFiles(directory.FullName, ProjectCommand.ProjectDirectoryName, SearchOption.AllDirectories))
            {
                if (!string.IsNullOrWhiteSpace(file))
                    pathList.AppendLine(file);
            }

            Console.WriteLine(pathList.ToString());
        }
    }
}