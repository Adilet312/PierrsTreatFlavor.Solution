using Microsoft.AspNetCore.Mvc;
using PierrsTreatFlavor.Models;

namespace  PierrsTreatFlavor.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}