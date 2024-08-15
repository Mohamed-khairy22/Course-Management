using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        ITIEntity entity = new ITIEntity();

        public IActionResult Index()
        {
            //Get all department
            List<Department> departmentList = entity.Departments.ToList();
            return View("Index", departmentList);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult SaveNew(Department dept)
        {
            if (dept.Name != null)
            {
                entity.Departments.Add(dept);
                entity.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            return View("New", dept);

        }
    }
}
