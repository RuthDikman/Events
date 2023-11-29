using events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class DataContextFake :IDataContext
    {
        public List<Event> EventList { get; set; }

        public DataContextFake()
        {
            EventList = new List<Event>();
            EventList.Add(new Event { Id = 1, Title = "e1", Start = new DateTime(2023, 11, 7, 12, 30, 0), End = new DateTime(2023, 11, 8, 12, 30, 0) });
            EventList.Add(new Event { Id = 2, Title = "e2", Start = new DateTime(2023, 11, 10, 12, 30, 0), End = new DateTime(2023, 11, 1, 12, 30, 0) });
            EventList.Add(new Event { Id = 3, Title = "e3", Start = new DateTime(2023, 11, 2, 12, 30, 0), End = new DateTime(2023, 11, 4, 12, 30, 0) });
    }
    }
}
