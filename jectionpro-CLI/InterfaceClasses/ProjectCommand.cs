using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using jectionpro_CLI.ResourceFiles;
using jectionpro_CLI.Classes;

namespace jectionpro_CLI.InterfaceClasses
{
    public static class ProjectCommand
    {
        internal const string ProjectDirectoryName = ".jpProject";
        internal const string ProjectDataFileName = "proj.xml";
        
        public static Command GetCommand()
        {
            var command = new Command("project", "Create and manipulate projects.")
            {
                InitCommand_Project.GetCommand(),
            };

            return command;
        }

        public static void VerifyCurrentProject()
        {
            if (GetCurrentProject() == null)
            {
                Console.WriteLine(ParsingErrorResources.NoProjectFound);
                Environment.Exit(1);
            }
        }

        public static Project GetCurrentProject()
        {
            return GetProjectInDirectory(Directory.GetCurrentDirectory());
        }

        public static Project GetProjectInDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine(ParsingErrorResources.InvalidDirectory);
                return null;
            }

            var projectPath = Path.Join(path, ProjectDirectoryName);
            var projectFilePath = Path.Join(projectPath, ProjectDataFileName);

            if (!Directory.Exists(projectPath))
            {
                Console.WriteLine(ParsingErrorResources.NoProjectFound);
                return null;
            }

            if (!File.Exists(projectFilePath))
            {
                Console.WriteLine(ParsingErrorResources.MissingProjectXML);
                return null;
            }

            var xmlDoc = XDocument.Load(projectFilePath);

            if (xmlDoc.Root is null)
            {
                Console.WriteLine(ParsingErrorResources.InvalidProjectXML);
                return null;
            }
            
            return Project.FromXml(xmlDoc.Root);
        }

        public static void Save(XElement xml)
        {
            xml.Save(File.CreateText(Path.Join(Directory.GetCurrentDirectory(), ProjectDirectoryName, ProjectDataFileName)));
        }
    }
}