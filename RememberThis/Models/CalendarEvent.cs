using System;

namespace RememberThis.Models
{
    public class CalendarEvent : GDEvent
    {
        public CalendarEvent(string eventAction, DateTime startDate, int priority) 
            :base(eventAction, startDate, EventType.Calendar, (Priority)priority)
        {
        }
    }
}