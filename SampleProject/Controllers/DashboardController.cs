using Microsoft.AspNetCore.Mvc;
using SampleProject.DTO;

namespace SampleProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AddDbContext db;

        public DashboardController(AddDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var EmployeeModel = db.Employees.Count();
            ViewBag.EmployeeCount = EmployeeModel;

            var TaskModel = db.Tasks.Count();
            ViewBag.TaskCount = TaskModel;

            var TMmodelComplete = db.TaskManagements.Where(v => v.Status.Equals("Completed")).Count();
            ViewBag.TmCount = TMmodelComplete;

            var TMmodelUncomplete = db.TaskManagements.Where(v => v.Status.Equals("NotCompleted")).Count();
            ViewBag.TmCountUncom = TMmodelUncomplete;

            return View();
        }
    }
}
