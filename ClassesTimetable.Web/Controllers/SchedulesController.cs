using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassesTimetable.Core.Entities;
using ClassesTimetable.Infrastructure.Data;

namespace ClassesTimetable.Web.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly DatabaseContext _context;

        public SchedulesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Schedules.Include(s => s.ClassRoom).Include(s => s.Group).Include(s => s.Lesson).Include(s => s.Teacher);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.ClassRoom)
                .Include(s => s.Group)
                .Include(s => s.Lesson)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id");
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id");
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,LessonId,ClassRoomId,GroupId,StartTime,EndTime,Id")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", schedule.ClassRoomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", schedule.GroupId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", schedule.LessonId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", schedule.TeacherId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", schedule.ClassRoomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", schedule.GroupId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", schedule.LessonId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", schedule.TeacherId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,LessonId,ClassRoomId,GroupId,StartTime,EndTime,Id")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = new SelectList(_context.ClassRooms, "Id", "Id", schedule.ClassRoomId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", schedule.GroupId);
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", schedule.LessonId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", schedule.TeacherId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.ClassRoom)
                .Include(s => s.Group)
                .Include(s => s.Lesson)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
