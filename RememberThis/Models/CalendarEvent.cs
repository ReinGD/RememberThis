using System;

namespace RememberThis.Models
{
    public class CalendarEvent : GDEvent
    {
        public CalendarEvent(string eventAction, DateTime startDate) 
            :base(eventAction, startDate, EventType.Calendar)
        {
        }
    }
}