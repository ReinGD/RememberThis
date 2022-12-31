using System;

namespace RememberThis.Models
{
    public class ToDoEvent : GDEvent
    {
        public bool completed { get; set; }
        public ToDoEvent(string eventAction, DateTime startDate, int priority) 
            : base(eventAction, startDate, EventType.ToDo, (Priority)priority)
        {
            completed = false;
        }

        public bool Conflicts(ToDoEvent incomingEvent)
        {
            bool result = true;

            if (!this.eventAction.Equals(incomingEvent.eventAction))
            {
               result = false;
            }

            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is ToDoEvent todo && eventAction.Equals(todo.eventAction) && startDate.Equals(todo.startDate);
        }
    }
}