using Demo.Models;
using ITI_task1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        ITIEntity entity =new ITIEntity();
        public IActionResult Index()
        {
            return View(entity.Employees.ToList());
        }
        public IActionResult Edit(int id)
        {
            ViewData["deptList"]= entity.Departments.ToList();
            Employee empModel = entity.Employees.FirstOrDefault(e => e.Id == id);
            return View(empModel);
        }
        [HttpPost]
        public IActionResult SaveEdite(int id,Employee newEmp)
        {
            if (newEmp.Name != null)
            {
               Employee oldEmp= entity.Employees.FirstOrDefault(e => e.Id == id);
                if (oldEmp != null)
                {
                    oldEmp.Name = newEmp.Name;
                    oldEmp.Salary = newEmp.Salary;
                    oldEmp.Address = newEmp.Address;
                    oldEmp.DepID = newEmp.DepID ;
                    oldEmp.image =newEmp.image;
                    entity.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            ViewData["deptList"] = entity.Departments.ToList();

            return View("Edit", newEmp);

        }
        
    }
}
