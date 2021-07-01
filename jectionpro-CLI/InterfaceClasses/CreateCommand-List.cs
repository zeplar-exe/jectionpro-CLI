using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class CreateCommand_List
    {
        public static Command GetCommand()
        {
            var command = new Command("create", "Create a new pin list inside of a directory.")
            {
                new Argument<string>("name")
            };

            command.Handler = CommandHandler.Create<string>(Handler);
            
            return command;
        }

        private static void Handler(string name)
        {
            var currentProject = ProjectCommand.GetCurrentProject();
            
            currentProject.Add(new PinList(name));
            Project.Save(currentProject.ToXml());
        }
    }
}