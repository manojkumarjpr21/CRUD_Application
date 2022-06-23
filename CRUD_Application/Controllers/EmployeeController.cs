using CRUD_Application.Data;
using CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context; 
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();   
            return View(result);
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
                var emp1 = new Employee()
                {
                    Name = emp.Name,
                    Salary = emp.Salary,
                    City = emp.City,
                    State = emp.State
                };
                context.Employees.Add(emp1);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty Field cann't be Submit";
                return View(emp);
            }
            
        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(x => x.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(x => x.Id == id);
            var result = new Employee()
            {
                Name=emp.Name,
                City=emp.City,
                Salary=emp.Salary,
                State = emp.State
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var emp1 = new Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                City = emp.City,
                State = emp.State
            };
            context.Employees.Update(emp1);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
             

        }
    }
}
