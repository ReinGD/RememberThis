using System;
using System.Windows.Data;

namespace RememberThis.Models
{
    public class GDEvent
    {
        public enum EventType 
        {
            Calendar,
            ToDo
        }

        public enum Priority : int
        {
            Low, Medium, High
        }

        public string eventAction { get; }
        public DateTime startDate { get; }

        public EventType eventType { get; }

        public Priority priority { get; }
        public GDEvent(string eventAction, DateTime startDate, EventType eventType, Priority priority )
        {
            this.eventAction = eventAction;
            this.startDate = startDate.Date;
            this.eventType = eventType;
            this.priority = priority;
        }


    }
}