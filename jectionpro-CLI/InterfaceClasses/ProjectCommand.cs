using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using jectionpro_CLI.ResourceFiles;
using ProjectCL = jectionpro_CLI.Classes.Project;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class ProjectCommand
    {
        internal const string ProjectDirectoryName = ".jpProject";
        internal const string ProjectDataFileName = "proj.xml";
        
        public static Command GetCommand()
        {
            var command = new Command("project", "Used to create and manipulate projects.")
            {
                InitCommand_Project.GetCommand(),
                DisplayCommand_Project.GetCommand()
            };

            return command;
        }

        public static ProjectCL GetCurrentProject()
        {
            return GetProjectInDirectory(Directory.GetCurrentDirectory());
        }

        public static ProjectCL GetProjectInDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine(ParsingErrorResources.InvalidDirectory);
                return null;
            }

            var projectFilePath = Path.Join(path, ProjectDataFileName);

            if (!File.Exists(projectFilePath))
            {
                Console.WriteLine(ParsingErrorResources.MissingProjXML);
                return null;
            }

            var xmlDoc = XDocument.Load(projectFilePath);

            if (xmlDoc.Root is null)
            {
                Console.WriteLine(ParsingErrorResources.InvalidProjXML);
                return null;
            }
            
            return ProjectCL.FromXml(xmlDoc.Root);
        }
    }
}