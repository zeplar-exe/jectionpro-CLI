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
            return this.Where(list =>
            {
                if (list != null)
                    return list.Name == name;

                return false;
            }).ToList();
        }
        
        public PinList GetPinListById(int id)
        {
            return this.DefaultIfEmpty(null).FirstOrDefault(list =>
            {
                if (list != null)
                    return list.Id == id;

                return false;
            });
        }

        public XElement ToXml()
        {
            var xml = new XElement("root");
            xml.Add(new XElement("name", Name));
            xml.Add(new XElement("openList", ListCommand.OpenList?.Id ?? -1));
            xml.Add(new XElement("openPin", PinCommand.OpenPin?.Id ?? -1));
            
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

            ListCommand.OpenList = project.GetPinListById(Convert.ToInt32(xml.Element("openList")?.Value));

            if (ListCommand.OpenList != null)
            {
                PinCommand.OpenPin = ListCommand.OpenList.GetPinById(Convert.ToInt32(xml.Element("openPin")?.Value));   
            }

            return project;
        }
    }
}