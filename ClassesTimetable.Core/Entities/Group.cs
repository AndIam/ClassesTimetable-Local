using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTimetable.Core.Entities
{
   public class Group : BaseEntity
    {
        public string Name { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Group()
        {
            Schedules = new List<Schedule>();
        }
    }
}
