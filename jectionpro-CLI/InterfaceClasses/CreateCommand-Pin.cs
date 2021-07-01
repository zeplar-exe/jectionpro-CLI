using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class CreateCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("create", "Create a new pin inside of the specified pin list.")
            {
                new Argument<string>("name")
            };
            
            command.Handler = CommandHandler.Create<string>(Handler);
            
            return command;
        }

        private static void Handler(string name)
        {
            var currentProject = ProjectCommand.GetCurrentProject();
            
            if (ListCommand.OpenList is null)
            {
                Console.WriteLine(ParsingErrorResources.ExpectedOpened, "list");
                return;
            }
            
            ListCommand.OpenList.Add(new Pin(name));
            Project.Save(currentProject.ToXml());
        }
    }
}