using Microsoft.AspNetCore.Mvc;
using SampleProject.DTO;
using SampleProject.Models.Task;
using Task = SampleProject.DTO.Task;

namespace SampleProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly AddDbContext db;

        public TaskController(AddDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = db.Tasks.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddTaskViewModel model)
        {

            if (ModelState.IsValid)
            {
                var task = new Task()
                {
                    TaskName = model.TaskName,
                    TaskType = model.TaskType
                };
                db.Tasks.Add(task);
                TempData["Success"] = "Task Added Successfully";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Model Is Not Valid";
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = db.Tasks.FirstOrDefault(v => v.TaskID.Equals(id));
            if (model != null)
            {
                var task = new DetailsTaskViewModel()
                {
                    TaskID = model.TaskID,
                    TaskName = model.TaskName,
                    TaskType = model.TaskType
                };
                return View(task);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = db.Tasks.FirstOrDefault(v => v.TaskID.Equals(id));
            if (model != null)
            {
                var task = new UpdateTaskViewModel()
                {
                    TaskID = model.TaskID,
                    TaskName = model.TaskName,
                    TaskType = model.TaskType
                };
                return View(task);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateTaskViewModel model)
        {
            var task = db.Tasks.FirstOrDefault(v => v.TaskID.Equals(model.TaskID));
            if(task != null)
            {
                task.TaskName=model.TaskName;
                task.TaskType=model.TaskType;

                db.SaveChanges();
                TempData["Success"] = "Task Updates Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = db.Tasks.FirstOrDefault(v => v.TaskID.Equals(id));
            if(model != null)
            {
                var task = new UpdateTaskViewModel()
                {
                    TaskID = model.TaskID,
                    TaskName = model.TaskName,
                    TaskType = model.TaskType
                };
                return View(task);
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteTask(int id)
        {
            var model = db.Tasks.FirstOrDefault(v => v.TaskID.Equals(id));
            if(model != null)
            {
                db.Tasks.Remove(model);
                TempData["Success"] = "Task Delete Successfully";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




    }
}
