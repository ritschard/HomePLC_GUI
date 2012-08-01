using System;
using System.Collections.Generic;
using System.Text;
using HomePLC.Forms;
using System.Windows.Forms;
using System.ComponentModel;
using NLog;
using System.Threading;

namespace HomePLC.Model
{
    public class DigitalPinTrigger : BaseTrigger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int pinNo = 0;
        public bool pinState = false;
        public ScriptEngine se;
        public ScriptEngine selectedActions = new ScriptEngine();

        private bool triggered = false;

        public int Pin
        {
            get
            {
                return pinNo;
            }

            set
            {
                pinNo = value;
            }
        }

        public override void Trigger(TriggeringEvent dogadjaj, Module modul)
        {

            if (!triggered)
            {
                foreach (var item in selectedActions)
                {
                    logger.Info("{0} executed script: {1}!!!", this.Name, item.Name);
                    item.Execute(modul);
                }
                triggered = true;
            }
        }

        public override bool InterestedInEvent(TriggeringEvent myEvent)
        {
            if (myEvent.Type == TriggeringEventType.ModuleEvent)
            {
                if ((myEvent.Pin == pinNo) && (myEvent.DigitalValue == pinState))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return base.InterestedInEvent(myEvent);
        }

        public override bool ConfigureSelf(ScriptEngine availableScripts)
        {
            bool result = false;
            se = availableScripts;

            using (DigitalPinTriggerForm form = new DigitalPinTriggerForm(this))
            {
                result = form.ShowDialog() == System.Windows.Forms.DialogResult.OK;

                if (result)
                    triggered = false;
            }
            return result;
        }

        override public string ToString()    // ovo postoji samo zbog liste, jer listbox koristi Object.ToString za caption
        {
            return "Trigger: " + this.Name;
        }
    }
}
