using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation.Peers;

namespace RememberThis.Models
{
    public class ToDoBook
    {

        private readonly List<ToDoEvent> _toDoEvents;

        public ToDoBook()
        {
            _toDoEvents = new List<ToDoEvent>();
        }
        public IEnumerable<ToDoEvent> GetAllEvents()
        {
            //gets all non completed events
            return _toDoEvents.Where(r => !r.completed);
        }

        public void AddEvent(ToDoEvent toDoEvent)
        {
            foreach (ToDoEvent item in _toDoEvents)
            {
                if (item.Conflicts(toDoEvent))
                {
                    throw new Exceptions.AddEventConflictException(item, toDoEvent);
                }
            }
        
            _toDoEvents.Add(toDoEvent);
        }

        public void Remove(ToDoEvent toDoEvent) 
        {
            ToDoEvent removeMe = null;
            foreach (ToDoEvent item in _toDoEvents)
            {
                if (item.Equals(toDoEvent) )
                {
                    removeMe = item;
                    break;            
                }
            }

            if (removeMe != null)
            {
                _toDoEvents.Remove(removeMe);
            }
        }
    }
}