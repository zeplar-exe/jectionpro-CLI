using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.IO;
using System.Text;
using System.Xml.Linq;
using ProjectCL = jectionpro_CLI.Classes.Project;
using jectionpro_CLI.ResourceFiles;
using Microsoft.VisualBasic.CompilerServices;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class InitCommand_Project
    {
        public static Command GetCommand()
        {
            var command = new Command("init", "Create a new project in the current directory.")
            {
                new Argument<string>("name"),
                new Option(new[] { "-f", "--force" }, "Create a project while ignoring an existing one.")
            };
            
            command.Handler = CommandHandler.Create<string, bool>(Handler);

            return command;
        }

        private static void Handler(string name, bool force)
        {
            var projectDirectory = Path.Join(Directory.GetCurrentDirectory(), ProjectCommand.ProjectDirectoryName);
            
            if (Directory.Exists(projectDirectory) && !force)
            {
                Console.WriteLine(ParsingErrorResources.ProjectExistsError);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(ParsingErrorResources.EmptyName);
                return;
            }
            
            var newDirectory = Directory.CreateDirectory(projectDirectory);
            newDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            
            ProjectCommand.Save(new ProjectCL(name).ToXml());

            Console.WriteLine(ParsingSuccessResources.SuccessfullyCreatedProject, name);
        }
    }
}