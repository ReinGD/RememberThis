using RememberThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberThis.Exceptions
{
    public class AddEventConflictException : Exception
    {
        public ToDoEvent _existingEvent { get; }
        public ToDoEvent _incomingEvent { get; }


        public AddEventConflictException(ToDoEvent existingEvent, ToDoEvent incomingEvent)
        {
            _existingEvent = existingEvent;
            _incomingEvent = incomingEvent;
        }
    }
}
