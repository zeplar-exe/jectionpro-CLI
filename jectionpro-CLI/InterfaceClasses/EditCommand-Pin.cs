using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class EditCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("edit", "Edit an existing pin.")
            {
                new Argument<int>("id", getDefaultValue: () => -1)
            };
            
            command.Handler = CommandHandler.Create<int>(Handler);
            
            return command;
        }

        public static void Handler(int id)
        {
            var currentProject = ProjectCommand.GetCurrentProject();

            // TODO: This, my brain is broken but I want to handle defaults and stuff
        }
    }
}