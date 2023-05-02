using Microsoft.AspNetCore.Mvc;
using PMS.Models;
using System.Diagnostics;
using DesignPatterns.Repository;
using DesignPatterns.Models.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IOptions<MyConfig> _config;

        private readonly IRepository<Plataform> _repository;
        public HomeController(
            //IOptions<MyConfig> config,
            IRepository<Plataform> repository)
        {
            //_config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //Log.GetInstance(_config.Value.PathLog).Save("Entro a index");

            IEnumerable<Plataform> lst = _repository.Get();

            return View("Index", lst);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}