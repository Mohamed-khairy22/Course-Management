using Demo.Models;
using Demo.Repositories;
using ITI_task1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        ITIEntity entity = new ITIEntity();
        IDeptRepo DeptRepo;
        ICrsRepo CrsRepo;

        public CourseController(ICrsRepo crsRepo,IDeptRepo deptRepo)
        {
            CrsRepo = crsRepo;
            DeptRepo = deptRepo;
        }

        public IActionResult Index()
        {
            List<Course> crs = CrsRepo.GetAll();
            return View(crs);
        }
        public IActionResult Edit(int id)
        {
            ViewData["depList"] = DeptRepo.GetAll();
            Course crsModel = CrsRepo.GetById(id);
            return View(crsModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id ,Course crsNew)
        {
            
            if(crsNew.Name!=null)
            {
               CrsRepo.Update(id, crsNew);
                return RedirectToAction("Index");

            }
            ViewData["depList"] = DeptRepo.GetAll();
            return View("Edit",crsNew);


        }
        public IActionResult addCrs()
        {
            ViewData["Depts"]= DeptRepo.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 

        public IActionResult saveNew(Course crs)
        {
            if (ModelState.IsValid)
            {
                CrsRepo.Insert(crs);
            }
            ViewData["Depts"] = DeptRepo.GetAll();
            return View("addCrs",crs);
        }
        public IActionResult deleteCrs(int id)
        {
           CrsRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult checkMinDegree(int minDegree,int Degree)
        {
            if (minDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
