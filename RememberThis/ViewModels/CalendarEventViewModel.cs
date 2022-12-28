using RememberThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberThis.ViewModels
{
    public class CalendarEventViewModel : ViewModelBase
    {
        private readonly CalendarEvent _calendarEvent;

        public string EventAction => _calendarEvent.eventAction;
        public string EventDate => _calendarEvent.startDate.Date.Equals(DateTime.Now.Date) ? "Today" : (_calendarEvent.startDate.Subtract(DateTime.Now).Days + 1) + " Day(s)";
        public CalendarEventViewModel(CalendarEvent calendarEvent)
        {
            _calendarEvent = calendarEvent;
        }
    }
}
