using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace jectionpro_CLI.Classes
{
    public class Pin
    {
        public string Name;
        public string Description;
        public List<PinContent> Content;
        public readonly Guid Id;

        public string Text { get; private set; }

        public Pin(string name, string text = "")
        {
            Name = name;
            Text = text;
            Id = Guid.NewGuid();
        }

        public XElement ToXml()
        {
            var xml = new XElement("pin");

            xml.Add("name", Name);
            xml.Add("description", Description);
            
            // TODO: Include pin content

            return xml;
        }
        
        public static Pin FromXml(XElement xml)
        {
            var pin = new Pin(xml.Element("name")?.Value, xml.Element("description")?.Value);

            // TODO: Include pin content
            
            return pin;
        }

        public void AppendText(string newText)
        {
            Text += newText;
        }
        
        public void OverwriteText(string newText)
        {
            Text = newText;
        }
    }
}