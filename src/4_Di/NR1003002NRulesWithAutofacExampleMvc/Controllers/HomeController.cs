using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NR1003002NRulesWithAutofacExampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NR1003002NRulesWithAutofacExampleMvc.Services;
using NRules;
using RulesAndModels.Models;

namespace NR1003002NRulesWithAutofacExampleMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISession _session;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger,
            ISession session, IPersonService personService)
        {
            _logger = logger;

            _session = session;

            _personService = personService;
        }

        public IActionResult Index()
        {

            var p1 = new Person(true, "Person1");
            var p2 = new Person(false, "Person2");
            var p3 = new Person(true, "Person3");
            var p4 = new Person(true, "Person4");
            var p5 = new Person(false, "Person5");
            var p6 = new Person(true, "Person6");

            _session.Insert(p1);
            _session.Insert(p2);
            _session.Insert(p3);
            _session.Insert(p4);
            _session.Insert(p5);
            _session.Insert(p6);
            _session.Fire();

            var people = new People
            {
                MalePersonList = _personService.GetPeople().ToList()
            };

            return View(people);
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
