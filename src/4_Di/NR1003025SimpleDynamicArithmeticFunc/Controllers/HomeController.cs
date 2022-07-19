using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NR1003025SimpleDynamicArithmeticFunc.Models;
using RulesAndModels.Services;
using System.Diagnostics;

namespace NR1003025SimpleDynamicArithmeticFunc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;

        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;

            _service = service;
        }

        public IActionResult Index()
        {
            _service.MyMethod();
            return View();
        }

        //arithmeticService.ArithmeticOperation

        public IActionResult SimpleArithmeticWithVars()
        {
            return View();
        }

        public IActionResult ArithmeticWithCompiledCode()
        {
            return View();
        }
        public IActionResult SimpleArithmeticWithCompiledCode()
        {
            return View();
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
