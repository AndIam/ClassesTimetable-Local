using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTimetable.Core.Entities
{
    public class TeacherLesson : BaseEntity
    {
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
        public Teacher Teacher { get; set; }
        public Lesson Lesson { get; set; }
    }
}
