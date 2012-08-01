using System;
using System.Collections.Generic;
using System.Text;
using HomePLC.Forms;
using System.Windows.Forms;
using System.ComponentModel;
using NLog;
using System.Threading;
using System.Xml;

namespace HomePLC.Model
{
    public class TimeTrigger : BaseTrigger
    {
        public enum TimeTriggerType
        {
            RunOnce,
            Continuous,
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ScriptEngine se;
        public ScriptEngine selectedActions = new ScriptEngine();
        private DateTime triggerTime = DateTime.Now;
        private TimeTriggerType runMode;
        private bool triggered = false;

        public TimeTriggerType TriggerMode 
        { 
            get 
            {
                return runMode;
            }
            set
            {
                runMode = value;
            }
        }
 
        public DateTime TriggerAt 
        {
            get
            {
                return triggerTime;
                
            }
            set
            {
                triggerTime = value;
            }
        }
                      
        public override void Trigger(TriggeringEvent dogadjaj, Module modul)
        {
            triggered = false;

            switch (runMode)
            {
                case TimeTriggerType.Continuous:
                    foreach (var item in selectedActions)
                    {
                        logger.Info("Trigger: {0}, executed script: {1}!!!", this.Name, item.Name);
                        item.Execute(modul);
                    }

                    triggered = true;
                break;

                case TimeTriggerType.RunOnce:
                    if (!triggered)
                    {
                        foreach (var item in selectedActions)
                        {
                            logger.Info("Trigger: {0}, executed script: {1}!!!", this.Name, item.Name);
                            item.Execute(modul);
                        }
                        triggered = true;
                        TriggerAt = DateTime.Now.AddMinutes(2);
                    }
                break;

            }


            
        }

        public override bool InterestedInEvent(TriggeringEvent myEvent)
        {
            if (myEvent.Type == TriggeringEventType.TimeEvent)
            {
                if ((myEvent.Time.Hour == triggerTime.Hour) && (myEvent.Time.Minute == triggerTime.Minute))
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

            using (TimeTriggerForm form = new TimeTriggerForm(this))
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
