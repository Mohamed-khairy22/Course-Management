using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StateManagmentController : Controller
    {
        public IActionResult setCookie() 
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("name", "Mohamed",options);
            Response.Cookies.Append("age", "25");
            return Content(" cookie saved");
        }
        public IActionResult getCookie()
        {
            string name = Request.Cookies["name"];
            int age = int.Parse( Request.Cookies["age"]);
            return Content($"Name is {name} age is {age}");

        }
        public IActionResult setSession()
        {
            HttpContext.Session.SetString("name", "Ahmed");
            HttpContext.Session.SetInt32("age",25);
            return Content("session data saved");
        }
        public IActionResult getSession()
        {
           string name = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"my name is {name} my age is {age}");
        }
        public IActionResult SetTembData()
        {
            TempData["msg"] = "hello its new";
            return Content("data saved");
        }
        public IActionResult GetTembData()
        {
            string data = "Empty message";
            if (TempData.ContainsKey("msg"))
                data = TempData.Peek("msg").ToString();
            return Content("get1 "+data);
        }
        public ActionResult Get2TembData()
        {
            string data = TempData["msg"].ToString();
            return Content("get2 "+data);

        }
    }
}
