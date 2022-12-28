using System;
using System.Collections.Generic;

namespace RememberThis.Models
{

    public class CalendarBook
    {
        private readonly List<CalendarEvent> _calendarEvents;

        public CalendarBook() 
        {
            _calendarEvents= new List<CalendarEvent>();
        }
        public IEnumerable<CalendarEvent> GetAllEvents()
        {
            return _calendarEvents;
        }

        public void AddEvent(CalendarEvent calendarEvent) 
        {
            _calendarEvents.Add(calendarEvent);
        }
    }
}