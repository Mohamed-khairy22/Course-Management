using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        ProductSampleData sampleData = new ProductSampleData();

        public IActionResult DEtails(int id)
        {
           Product productModel= sampleData.GetById(id);
            return View("ProductDetails",productModel);
            
        }
        public IActionResult VAll()
        {
            List<Product> productList = sampleData.GetAll();
            return View("ShowAll", productList);
        }

        #region Test part
        /*
        public string show()
        {
            return "First view";
        }
        public ContentResult showContent()
        {
            ContentResult content = new ContentResult();
            content.Content = "hello from contect";
            return content;

        }
        public ViewResult showView()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "view1";
            return viewResult;
        }
        public JsonResult showJson()
        {
            JsonResult result = new JsonResult(new { id = 1, name = "Mohamed" });
            return result;
        }
        public IActionResult showMex(int id)
        {
            if (id == 1)
            {
                return View("view1");
            }
            else
            {
               
                return Content("hello from contect");
            }
        }*/
        #endregion
    }
}
