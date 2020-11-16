using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTimetable.Core.Entities
{
    public class Schedule : BaseEntity
    {
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
        public int ClassRoomId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Teacher Teacher { get; set; }
        public Lesson Lesson { get; set; }
    }
}
