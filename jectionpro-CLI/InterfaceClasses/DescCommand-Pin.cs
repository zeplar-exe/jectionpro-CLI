using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class DescCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("desc", "Edit the description of an opened pin.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }
        
        private static void Handler()
        {
            var currentProject = ProjectCommand.GetCurrentProject();

            PinCommand.VerifyOpenPin();

            var text = PinCommand.OpenPin.Description;
            PinCommand.OpenPin.Description = ConsoleEditor.ReadDynamicInput(text);
            
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}