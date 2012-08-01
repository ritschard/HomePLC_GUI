using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;

namespace HomePLC.Model
{
    public class TriggerEngine : BindingList<BaseTrigger>
    {
        private List<BaseTrigger> fTriggerList;

        public void Save(string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element = doc.CreateElement("triggers");
            doc.AppendChild(element);

            foreach (BaseTrigger s in this)
            {
                XmlElement e = doc.CreateElement("trigger");
                XmlAttribute a = doc.CreateAttribute("ID");

                a.Value = s.ID.ToString();
                e.Attributes.Append(a);
                s.Save(e);
                doc.DocumentElement.AppendChild(e);
            }

            doc.Save(filename);
        }


        public TriggerEngine()
        {
            fTriggerList = new List<BaseTrigger>();
        }

        public List<BaseTrigger> Triggers
        {
            get
            {
                return fTriggerList;
            }
        }
    }
}
