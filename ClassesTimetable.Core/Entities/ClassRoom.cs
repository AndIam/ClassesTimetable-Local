using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTimetable.Core.Entities
{
    public class ClassRoom : BaseEntity
    {
        public string Name { get; set; }
        public bool HavePC { get; set; }
        public bool HaveBoard { get; set; }
    }
}
