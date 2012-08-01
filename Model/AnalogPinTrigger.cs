using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using HomePLC.Forms;

namespace HomePLC.Model
{
    public class AnalogPinTrigger : BaseTrigger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int pinNo = 0;
        public byte pinValue = 0;
        public ScriptEngine se;
        public ScriptEngine selectedActions = new ScriptEngine();

        private int triggered = 0;

        public override void Trigger(TriggeringEvent dogadjaj, Module modul)
        {

            if (triggered >= 0)
            {
                foreach (var item in selectedActions)
                {
                    logger.Info("{0} executed script: {1}!!!", this.Name, item.Name);
                    item.Execute(modul);
                }
                triggered++;
            }
        }

        public override bool InterestedInEvent(TriggeringEvent myEvent)
        {
            if (myEvent.Type == TriggeringEventType.ModuleEvent)
            {
                if ((myEvent.Pin == pinNo) && (myEvent.AnalogValue > pinValue))
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

            using (AnalogPinTriggerForm form = new AnalogPinTriggerForm(this))
            {
                result = form.ShowDialog() == System.Windows.Forms.DialogResult.OK;

                if (result)
                    triggered = 0;
            }

            return result;
        }

        override public string ToString()   
        {
            return "Trigger: " + this.Name;
        }
    }
}
