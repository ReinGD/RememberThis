using System;

namespace RememberThis.Models
{
    public class GDEvent
    {
        public enum EventType 
        {
            Calendar,
            ToDo
        }

        public string eventAction { get; }
        public DateTime startDate { get; }

        public EventType eventType { get; }

        public GDEvent(string eventAction, DateTime startDate, EventType eventType)
        {
            this.eventAction = eventAction;
            this.startDate = startDate.Date;
            this.eventType = eventType;
        }


    }
}