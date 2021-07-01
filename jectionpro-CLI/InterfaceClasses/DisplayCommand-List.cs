using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class DisplayCommand_List
    {
        public static Command GetCommand()
        {
            var command = new Command("display", "Lists all pin lists in the current directory. [not implemented]");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            var outputList = new StringBuilder();
            
            outputList.AppendLine("Pin lists in current project:");
            outputList.AppendLine();
            
            var currentProject = ProjectCommand.GetCurrentProject();

            currentProject.ForEach(list => outputList.AppendLine(list.Name + $" (ID: {list.Id})"));

            Console.WriteLine(outputList.ToString());
        }
    }
}