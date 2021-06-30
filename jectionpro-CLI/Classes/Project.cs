using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace jectionpro_CLI.Classes
{
    public class Project : List<PinList>
    {
        public string Name;
        
        public Project(string name)
        {
            Name = name;
        }

        public XElement ToXml()
        {
            var xml = new XElement("project");
            xml.Add("name", Name);
            
            var pinLists = new XElement("pinlists");

            foreach (var list in this)
                pinLists.Add(list.ToXml());
                
            xml.Add(pinLists);

            return xml;
        }

        public static Project FromXml(XElement xml)
        {
            var project = new Project(xml.Element("name")?.Value);

            foreach (var pinList in xml.Elements("pinlists"))
            {
                project.Add(PinList.FromXml(pinList));
            }

            return project;
        }
    }
}