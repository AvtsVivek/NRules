using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NR1003005NRulesWithAutofacGulpAndNPM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NR1003005NRulesWithAutofacGulpAndNPM.Services;
using NRules;
using RulesAndModels.Models;
using RulesAndModels.Services;

namespace NR1003005NRulesWithAutofacGulpAndNPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;
        private readonly ISession _session;
        private readonly IPersonService _personService;

        private List<double> NumberData = new List<double>();

        public HomeController(ILogger<HomeController> logger, 
            IService service, ISession session,
            IPersonService personService
            )
        {
            _logger = logger;

            _service = service;

            _session = session;

            _personService = personService;

            NumberData.Add(1.0);
            NumberData.Add(2.0);
            NumberData.Add(3.0);
            NumberData.Add(4.0);
            NumberData.Add(5.0);
            NumberData.Add(6.0);
            NumberData.Add(7.0);
            NumberData.Add(8.0);


        }

        public IActionResult Index()
        {
            _service.MyMethod();

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

            _session.Insert(NumberData);

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
