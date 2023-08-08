using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        // public String Index()
        // {
        //     return "Hello Store App";
        // }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}