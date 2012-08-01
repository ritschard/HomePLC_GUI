using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;

namespace HomePLC.Model
{
    abstract public class BaseTrigger
    {
        private Guid fTriggerID;
        private string fTriggerName;

        public BaseTrigger()
        {
            fTriggerID = Guid.NewGuid();
            fTriggerName = "";
        }

        virtual public bool InterestedInEvent(TriggeringEvent myEvent)
        {
            return false;
        }

        virtual public void Save(XmlElement xe)
        {
            
        }

        abstract public void Trigger(TriggeringEvent myEvent, Module modul);

        abstract public bool ConfigureSelf(ScriptEngine availableScripts);

        public Guid ID
        {
            get
            {
                return fTriggerID;
            }
        }

        public string Name
        {
            get
            {
                return fTriggerName;
            }

            set
            {
                fTriggerName = value;
            }
        }

        override public string ToString()    // ovo postoji samo zbog liste, jer listbox koristi Object.ToString za caption
        {
            return "Trigger: " + fTriggerName;
        }

    }
}
