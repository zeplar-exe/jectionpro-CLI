using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace jectionpro_CLI.Classes
{
    public class Pin
    {
        public string Name;
        public string Description;
        public string TextContent;
        public int Id;
        public PinList Parent;
        
        public Pin(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public XElement ToXml()
        {
            var xml = new XElement("pin");

            xml.Add(new XElement("name", Name));
            xml.Add(new XElement("description", Description));
            xml.Add(new XElement("textcontent", TextContent));
            xml.Add(new XElement("id", Id));

            return xml;
        }
        
        public static Pin FromXml(XElement xml)
        {
            var pin = new Pin(xml.Element("name")?.Value, xml.Element("description")?.Value);
            pin.TextContent = xml.Element("textcontent")?.Value;
            pin.Id = Convert.ToInt32(xml.Element("id")?.Value);
            
            return pin;
        }

        public void AppendText(string newText)
        {
            TextContent += newText;
        }
        
        public void OverwriteText(string newText)
        {
            TextContent = newText;
        }
    }
}