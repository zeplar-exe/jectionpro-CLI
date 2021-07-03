using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using jectionpro_CLI.Classes;
using jectionpro_CLI.ResourceFiles;

namespace jectionpro_CLI.InterfaceClasses
{
    public class DeleteCommand_List
    {
        public static Command GetCommand()
        {
            var command = new Command("delete", "Delete an existing pin list.");

            command.Handler = CommandHandler.Create(Handler);
            
            return command;
        }
        
        private static void Handler()
        {
            var currentProject = ProjectCommand.GetCurrentProject();
            
            ListCommand.VerifyOpenList();

            currentProject.Remove(ListCommand.OpenList);
            ListCommand.OpenList = null;
            ProjectCommand.Save(currentProject.ToXml());
        }
    }
}