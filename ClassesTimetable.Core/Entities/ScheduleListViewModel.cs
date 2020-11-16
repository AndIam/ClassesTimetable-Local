using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ClassesTimetable.Core.Entities
{
    public class ScheduleListViewModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }
        public SelectList Groups { get; set; }
        public string Name { get; set; }
    }
}
