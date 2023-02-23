using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleProject.DTO;
using SampleProject.Models.TaskManagement;

namespace SampleProject.Controllers
{
    public class TaskManagementController : Controller
    {
        private readonly AddDbContext db;

        public TaskManagementController(AddDbContext db)
        {
            this.db = db;
        }

        private void FillTask()
        {
            List<SelectListItem> TaskNameList = (from t in db.Tasks
                                                 orderby t.TaskID
                                                 select new SelectListItem() { Text = t.TaskName, Value = t.TaskName }).ToList();
            ViewBag.TaskList = TaskNameList;
        }

        private void FillEmployee()
        {
            List<SelectListItem> EmployeeNameList = (from e in db.Employees
                                                     orderby e.EmployeeID
                                                     select new SelectListItem() { Text = e.EmployeeName, Value = e.EmployeeName }).ToList();
            ViewBag.EmployeeList = EmployeeNameList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = db.TaskManagements.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            FillTask();
            FillEmployee();
            return View();
        }

        [HttpPost]

        public IActionResult Create(AddTMViewModel addTMViewModel)
        {
            FillTask();
            FillEmployee();

            if (ModelState.IsValid)
            {
                var model = new TaskManagement()
                {
                    TaskName = addTMViewModel.TaskName,
                    EmployeeName = addTMViewModel.EmployeeName,
                    TDate = addTMViewModel.TDate,
                    TTime = addTMViewModel.TTime,
                    Status = addTMViewModel.Status

                };
                db.TaskManagements.Add(model);
                TempData["Success"] = "Task Allocation is Successfully";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Model Is Not Valid";
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            FillTask();
            FillEmployee();
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(id));
            if (model != null)
            {
                var tm = new UpdateTMViewModel()
                {
                    TaskManagementID = model.TaskManagementID,
                    TaskName = model.TaskName,
                    EmployeeName = model.EmployeeName,
                    TDate = model.TDate,
                    TTime = model.TTime,
                    Status = model.Status
                };
                return View(tm);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateTMViewModel updateTMViewModel)
        {
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(updateTMViewModel.TaskManagementID));
            if (model != null)
            {
                model.TaskName = updateTMViewModel.TaskName;
                model.EmployeeName = updateTMViewModel.EmployeeName;
                model.TDate = updateTMViewModel.TDate;
                model.TTime = updateTMViewModel.TTime;
                model.Status = updateTMViewModel.Status;

                db.SaveChanges();
                TempData["Success"] = "Task Allocation Update is Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            FillTask();
            FillEmployee();
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(id));
            if (model != null)
            {
                var tm = new UpdateTMViewModel()
                {
                    TaskManagementID = model.TaskManagementID,
                    TaskName = model.TaskName,
                    EmployeeName = model.EmployeeName,
                    TDate = model.TDate,
                    TTime = model.TTime,
                    Status = model.Status
                };
                return View(tm);
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteTM(int id)
        {
            FillTask();
            FillEmployee();
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(id));
            if (model != null)
            {
                db.TaskManagements.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult TaskCompletion(int id)
        {
            FillTask();
            FillEmployee();
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(id));
            if(model != null)
            {
                var tc = new CompleteTMViewModel()
                {
                    TaskManagementID = model.TaskManagementID,
                    TaskName = model.TaskName,
                    EmployeeName = model.EmployeeName
                };
                return View(tc);
            }
            return View();
        }

        [HttpPost]
        public IActionResult TaskCompletion(CompleteTMViewModel completeTMViewModel)
        {
            FillTask();
            FillEmployee();
            var model = db.TaskManagements.FirstOrDefault(v => v.TaskManagementID.Equals(completeTMViewModel.TaskManagementID));
            if (model != null)
            {
                model.Status = "Completed";

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}
