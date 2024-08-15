using Demo.Models;
using Demo.Repositories;
using ITI_task1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_task1.Controllers
{
    public class InstructorController : Controller
    {
       // ITIEntity Entity =new ITIEntity();
        IInstRepo InstRepo;
        ICrsRepo CrsRepo;
        IDeptRepo DeptRepo;

        public InstructorController(IInstRepo instRepo,ICrsRepo crsRepo,IDeptRepo deptRepo)
        {
            DeptRepo = deptRepo;
            InstRepo = instRepo;
            CrsRepo = crsRepo;
        }
        //show all instructors
        [Authorize]
        public IActionResult Index()
        {
            List<Instructor> InstrModel = InstRepo.GetAll();
            return View(InstrModel);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor =InstRepo.GetById(id);
            
            return PartialView("_EditPartial",instructor);
        }
        //Show only one instructor
        public IActionResult Edit(int id)
        {
            ViewData["depList"] = DeptRepo.GetAll();
            ViewData["crsList"] = CrsRepo.GetAll();
            Instructor instModel= InstRepo.GetById(id);
            return View(instModel);
        } 
        public IActionResult SaveEdit(int id,Instructor newInst)
        {
            if (newInst.Name != null)
            {
                InstRepo.Update(id, newInst);
                return RedirectToAction("Index");
            }
            ViewData["depList"] = DeptRepo.GetAll();
            ViewData["crsList"] = CrsRepo.GetAll();
            return View("Edit", newInst);


        }
        public IActionResult AddInst()
        {
            ViewData["depList"] = DeptRepo.GetAll();
            ViewData["crsList"] = CrsRepo.GetAll();
            return View("AddInst",new Instructor());
        }
        public IActionResult saveInst(Instructor newInst)
        {
            if (newInst.Name != null)
            {
                InstRepo.Insert(newInst);
                return RedirectToAction("Index");
            }
            ViewData["depList"] = DeptRepo.GetAll();
            ViewData["crsList"] = CrsRepo.GetAll();
            return View("AddInst",newInst);
        }
        public IActionResult deletion(int id)
        {
            InstRepo.Delete(id);
            return RedirectToAction("Index");
        }

        //show instractors for one department

        public IActionResult showCrsPerDept(int deptId)
        {
            List<Course> Crs = CrsRepo.crsPerDept(deptId);    
            return Json(Crs);
        }

    }
}
