using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using jectionpro_CLI.InterfaceClasses;

namespace jectionpro_CLI.Classes
{
    public class Project : List<PinList>
    {
        public string Name;
        
        public Project(string name)
        {
            Name = name;
        }

        public new void Add(PinList item)
        {
            item.Id = Count;
            base.Add(item);
        }

        public List<PinList> GetPinListsByName(string name)
        {
            return this.Where(list => list.Name == name).ToList();
        }
        
        public PinList GetPinListById(int id)
        {
            return this.DefaultIfEmpty(null).First(list => list.Id == id);
        }

        public static void Save(XElement xml)
        {
            xml.Save(File.CreateText(Path.Join(Directory.GetCurrentDirectory(), ProjectCommand.ProjectDirectoryName, ProjectCommand.ProjectDataFileName)));
        }

        public XElement ToXml()
        {
            var xml = new XElement("root");
            xml.Add(new XElement("name", Name));
            
            var pinLists = new XElement("pinlists");

            foreach (var pinList in this)
                pinLists.Add(pinList.ToXml());
                
            xml.Add(pinLists);

            return xml;
        }

        public static Project FromXml(XElement xml)
        {
            var project = new Project(xml.Element("name")?.Value);

            foreach (var pinList in xml.Element("pinlists").Elements("pinlist"))
            {
                project.Add(PinList.FromXml(pinList));
            }

            return project;
        }
    }
}