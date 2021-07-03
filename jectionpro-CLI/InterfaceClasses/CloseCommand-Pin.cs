using System.CommandLine;
using System.CommandLine.Invocation;
using jectionpro_CLI.Classes;

namespace jectionpro_CLI.InterfaceClasses
{
    public class CloseCommand_Pin
    {
        public static Command GetCommand()
        {
            var command = new Command("close", "Close the currently opened pin.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }

        private static void Handler()
        {
            var currentProject = ProjectCommand.GetCurrentProject();
            
            PinCommand.OpenPin = null;
            
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}