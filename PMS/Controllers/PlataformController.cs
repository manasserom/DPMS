using Microsoft.AspNetCore.Mvc;

namespace DPMS.Controllers
{
    public class PlataformController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
