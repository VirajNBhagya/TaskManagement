using Microsoft.AspNetCore.Mvc;
using SampleProject.DTO;

namespace SampleProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AddDbContext context;

        public EmployeeController(AddDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult EmployeeList()
        {
            List<Employee> model = context.Employees.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["Success"] = "Employee Added Successfully";
                return RedirectToAction("EmployeeList");
            }

            TempData["Error"] = "Model Is Not Valid";


            return View(emp);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee model = context.Employees.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee model = context.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["Success"] = "Employee Update is Successfully";
            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee model = context.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee model = context.Employees.Find(id);
            if (model != null)
            {
                context.Employees.Remove(model);
                context.SaveChanges();
                TempData["Success"] = "Employee Delete Successfully";
                return RedirectToAction("EmployeeList");
            }
            return View(model);
        }
    }
}
