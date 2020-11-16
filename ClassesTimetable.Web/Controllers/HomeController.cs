using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClassesTimetable.Web.Models;
using ClassesTimetable.Core.Interfaces;
using System.Collections;
using ClassesTimetable.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using ClassesTimetable.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassesTimetable.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext db;

        public HomeController(DatabaseContext context)
        {
            db = context;
        }

        public ActionResult Index(int? group, string name)
        {
            IQueryable<Schedule> schedules = db.Schedules.Include(p => p.Group);
            if (group != null && group != 0)
            {
                schedules = schedules.Where(p => p.GroupId == group);
            }

            List<Group> groups = db.Groups.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            groups.Insert(0, new Group { Name = "Все", Id = 0 });

            ScheduleListViewModel viewModel = new ScheduleListViewModel
            {
                Schedules = schedules.ToList(),
                Groups = new SelectList(groups, "Id", "Name"),
                Name = name
            };
            return View(viewModel);
        }
    }
}
