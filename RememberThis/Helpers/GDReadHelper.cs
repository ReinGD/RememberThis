using Newtonsoft.Json;
using RememberThis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RememberThis.Helpers
{
    public class GDReadHelper
    {
        public static List<GDEvent> GetEvents(string jsonFile) 
        {
            List<GDEvent> result;

            using(StreamReader r = new StreamReader(jsonFile)) 
            {
                string json = r.ReadToEnd(); 
                result = JsonConvert.DeserializeObject<List<GDEvent>>(json);
            }

            return result;
        }

        public static void SaveEvents(string jsonFile, IEnumerable<CalendarEvent> calendarEvents, IEnumerable<ToDoEvent> toDoEvents) 
        {
            List<GDEvent> result = new List<GDEvent>();
            foreach (CalendarEvent item in calendarEvents)
            {
                result.Add(item as GDEvent);
            }
            foreach (ToDoEvent item in toDoEvents)
            {
                result.Add(item as GDEvent);
            }



            using (StreamWriter file = File.CreateText(jsonFile)) 
            {
                JsonSerializer serializer= new JsonSerializer();
                serializer.Serialize(file, result);
            }
        }

    }
}
