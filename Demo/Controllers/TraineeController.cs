using Demo.Models;
using Demo.ViewModel;
using ITI_task1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TraineeController : Controller
    {
        ITIEntity entity = new ITIEntity();
        TrineeViewModel trineeViewModel = new TrineeViewModel();

        public IActionResult Index()
        {
            List<TrineeViewModel> trineeViewModels = new List<TrineeViewModel>();
            List<Trainee> trainees = entity.traines.ToList();
            crsResult trineeResult= new crsResult();
            Course course = new Course();
            foreach (var traine in trainees)
            {
                TrineeViewModel trineeViewModel = new TrineeViewModel();

                trineeResult = entity.crsResult.FirstOrDefault(cr => cr.traineeId == traine.Id);
                course = entity.courses.FirstOrDefault(c => c.Id == trineeResult.crsId);
                trineeViewModel.TraineeId = traine.Id;
                trineeViewModel.TraineeName = traine.Name;
                trineeViewModel.CrsName = course.Name;
                trineeViewModel.TraineeGrade = trineeResult.Degree;
                if ((trineeViewModel.TraineeGrade < 60))
                    trineeViewModel.TextColor = "red";
                else trineeViewModel.TextColor = "green";
                
                trineeViewModels.Add(trineeViewModel);
            
            }

            return View(trineeViewModels);

        }
        public IActionResult details(int id)
        {

            Trainee trainee = entity.traines.FirstOrDefault(t => t.Id == id);
            crsResult trineeResult = entity.crsResult.FirstOrDefault(cr => cr.traineeId == id);
            Course course = entity.courses.FirstOrDefault(c => c.Id == trineeResult.crsId);
            trineeViewModel.TraineeId = trainee.Id;
            trineeViewModel.TraineeName =trainee.Name;
            trineeViewModel.CrsName = course.Name;
            trineeViewModel.TraineeGrade = trineeResult.Degree;
            if ((trineeViewModel.TraineeGrade < 60))
                trineeViewModel.TextColor = "red";
            else trineeViewModel.TextColor = "green";
            return View(trineeViewModel);
        }
    }
}
