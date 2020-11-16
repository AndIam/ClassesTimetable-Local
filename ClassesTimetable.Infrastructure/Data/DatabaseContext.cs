using ClassesTimetable.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTimetable.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
            // DO NOTHING
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherLesson>().HasKey(sc => new { sc.LessonId, sc.TeacherId });

        }
    }
}
