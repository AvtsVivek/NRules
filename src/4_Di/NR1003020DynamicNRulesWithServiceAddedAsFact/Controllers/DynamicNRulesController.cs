using Microsoft.AspNetCore.Mvc;
using NR1003020DynamicNRulesWithServiceAddedAsFact.Infra;
using NRules;
using RulesAndModels.Models;
using RulesAndModels.Services;
using System;
using System.Linq;

namespace NR1003020DynamicNRulesWithServiceAddedAsFact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicNRulesController : Controller
    {

        private readonly IRuleSharpRepository _ruleSharpRepository;
        private readonly IPersonService _personService;
        public DynamicNRulesController(IRuleSharpRepository ruleSharpRepository
            , IPersonService personService
            )
        {
            _ruleSharpRepository = ruleSharpRepository;
            _personService = personService;
        }

        [HttpPost("ProcessTextRule")]
        public JsonResult ProcessTextRule([FromBody] RuleData ruleData)
        {
            
            var ruleString = ruleData.RuleString;

            _ruleSharpRepository.AddNamespace("System");
            _ruleSharpRepository.AddNamespace("RulesAndModels.Services");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            _ruleSharpRepository.AddReference(typeof(Console).Assembly);
            _ruleSharpRepository.AddReference(typeof(Person).Assembly);


            _ruleSharpRepository.LoadText(ruleString);

            var ruleSets = _ruleSharpRepository.GetRuleSets().ToList();

            var rules = _ruleSharpRepository.GetRules().ToList();

            var factory = _ruleSharpRepository.Compile();

            //Create a rules session
            
            var session = factory.CreateSession();
            
            var p1 = new Person(true, "malePerson1");
            var p2 = new Person(false, "femalePerson1");
            var p3 = new Person(true, "malePerson2");
            var p4 = new Person(true, "malePerson3");
            var p5 = new Person(false, "femalePerson2");
            var p6 = new Person(true, "malePerson4");
            var p7 = new Person(false, "femalePerson3");

            session.Insert(p1);
            session.Insert(p2);
            session.Insert(p3);
            session.Insert(p4);
            session.Insert(p5);
            session.Insert(p6);
            session.Insert(p7);
            session.Insert(_personService);

            //Fire rules
            session.Fire();

            var people = _personService.GetPeople();
            var jsonResult = Json(people);

            return jsonResult;
        }
    }
    public class RuleData
    {
        public string RuleString { get; set; }
    }
}