using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class EditCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("edit", "Edit an existing pin. [not implemented]");
            
            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            var currentProject = ProjectCommand.GetCurrentProject();

            PinCommand.VerifyOpenPin();

            var text = PinCommand.OpenPin.TextContent;
            PinCommand.OpenPin.TextContent = ConsoleEditor.ReadDynamicInput(text);
            
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}