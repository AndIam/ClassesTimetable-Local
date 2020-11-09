using ClassesTimetable.Core.Entities;
using ClassesTimetable.Core.Interfaces;
using ClassesTimetable.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassesTimetable.Web.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IRepository<Teacher> _repository;
        public DatabaseContext _db;

        public TeachersController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Teachers.ToList());
            ;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(teacher);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _db.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _db.Teachers.Find(id);
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _db.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(teacher);
                    _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        public bool TeacherExists(int id)
        {
            return _db.Teachers.Any(x => x.Id == id);
        }
    }
}
