using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberThis.Models
{
    public class Registrator
    {
        private readonly CalendarBook _calendarBook;
        private readonly ToDoBook _toDoBook;
        public string Name { get; }
        public Registrator(string name) 
        {
            Name = name;
            _calendarBook = new CalendarBook();
            _toDoBook = new ToDoBook();
        }

        public IEnumerable<CalendarEvent> GetCalendarEvents() 
        {
            return _calendarBook.GetAllEvents();
        }
        public IEnumerable<ToDoEvent> GetToDoEvents()
        {
            return _toDoBook.GetAllEvents();
        }

        public void AddEvent(ToDoEvent todoEvent)
        {
            _toDoBook.AddEvent(todoEvent);
        }
        public void AddEvent(CalendarEvent calendarEvent)
        {
            _calendarBook.AddEvent(calendarEvent);
        }

        public void RemoveEvent(ToDoEvent todoEvent) 
        {
            _toDoBook.Remove(todoEvent);
        }
    }
}
