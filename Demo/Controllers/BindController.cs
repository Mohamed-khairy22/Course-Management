using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BindController : Controller
    {
        public IActionResult testPremative(int id,string name,int age)
        {
            return Content($"id = {id} and name = {name}");
        }
    }
}
