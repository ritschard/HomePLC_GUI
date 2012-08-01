using System;
using System.Collections.Generic;
using System.Text;

namespace HomePLC.Model
{
    public enum TriggeringEventType
    {
        TimeEvent,
        ModuleEvent,
    }
        
    public class TriggeringEvent
    {
        public TriggeringEventType Type;

        public DateTime Time;
        public int Pin;
        public byte AnalogValue;
        public bool DigitalValue;

        public TriggeringEvent()
        {
        }

        public TriggeringEvent(TriggeringEventType type, int pin, bool state)
        {
            Type = type;
            Pin = pin;
            DigitalValue = state;
        }

        public TriggeringEvent(TriggeringEventType type, int pin, byte value)
        {
            Type = type;
            Pin = pin;
            AnalogValue = value;
        }

        public TriggeringEvent(TriggeringEventType type, DateTime time)
        {
            Type = type;
            Time = time;
        }

    }
}
