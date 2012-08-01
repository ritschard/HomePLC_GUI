using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.ComponentModel;

namespace HomePLC.Model
{
    public class ScriptEngine : BindingList<Script>
    {
        public void Save(string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element = doc.CreateElement("scripts");
            doc.AppendChild(element);

            foreach (Script s in this)
            {
                XmlElement e = doc.CreateElement("script");
                XmlAttribute a = doc.CreateAttribute("ID");

                a.Value = s.ID.ToString();
                e.Attributes.Append(a);
                s.Save(e);
                doc.DocumentElement.AppendChild(e);
            }

            doc.Save(filename);
        }

        public void Load(string filename)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(filename);

            this.Clear();

            foreach (XmlElement e in doc.DocumentElement.ChildNodes)
            {
                this.Add(new Script(new Guid(e.Attributes["ID"].Value), e));
            }
        }
    }
}
