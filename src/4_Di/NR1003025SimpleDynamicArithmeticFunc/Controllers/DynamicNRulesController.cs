using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using NR1003025SimpleDynamicArithmeticFunc.Infra;
using NRules;
using RulesAndModels.Models;
using RulesAndModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NR1003025SimpleDynamicArithmeticFunc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicNRulesController : Controller
    {

        private readonly IRuleSharpRepository _ruleSharpRepository;
        private readonly IArithmeticService _arithmeticService;
        public DynamicNRulesController(IRuleSharpRepository ruleSharpRepository
            , IArithmeticService arithmeticService
            )
        {
            _ruleSharpRepository = ruleSharpRepository;
            _arithmeticService = arithmeticService;
        }

        [HttpPost("ProcessCSharpTextSimplifiedAsync")]
        public async Task<JsonResult> ProcessCSharpTextSimplifiedAsync([FromBody] RuleData ruleData)
        {
            ruleData.ConvertStringArrayToNumberArray();

            var scriptOptions = ScriptOptions.Default;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            scriptOptions.AddReferences(typeof(System.Int32).Assembly);

            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");

            var codeString = @"Func<List<double>, double> arithmeticSum = dList =>
            {
                var finalResult = 0.0;" + Environment.NewLine

                + ruleData.CodeTextString + Environment.NewLine +

                @"return finalResult;
            };

            return arithmeticSum;";

            Func<List<double>, double> arithmeticSum = await CSharpScript.EvaluateAsync<Func<List<double>, double>>(codeString, scriptOptions);

            var finalResult = arithmeticSum(ruleData.a.ToList());

            return Json(finalResult);
        }

        [HttpPost("ProcessCSharpTextAsync")]
        public async Task<JsonResult> ProcessCSharpTextAsync([FromBody] RuleData ruleData)
        {
            ruleData.ConvertStringArrayToNumberArray();

            var scriptOptions = ScriptOptions.Default;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            scriptOptions.AddReferences(typeof(System.Int32).Assembly);

            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");

            Func<List<double>, double> arithmeticSum = await CSharpScript.EvaluateAsync<Func<List<double>, double>>(ruleData.CodeTextString, scriptOptions);

            var finalResult = arithmeticSum(ruleData.a.ToList());

            return Json(finalResult);
        }

        [HttpPost("ProcessTextRule")]
        public JsonResult ProcessTextRule([FromBody] RuleData ruleData)
        {

            ruleData.ConvertStringArrayToNumberArray();

            //return Json("");

            var ruleString = ruleData.RuleString;

            _ruleSharpRepository.AddNamespace("System");
            _ruleSharpRepository.AddNamespace("RulesAndModels.Services");
            _ruleSharpRepository.AddNamespace("System.Collections.Generic");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            _ruleSharpRepository.AddReference(typeof(Console).Assembly);
            _ruleSharpRepository.AddReference(typeof(Person).Assembly);
            _ruleSharpRepository.AddReference(this.GetType().Assembly);


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
            session.Insert(_arithmeticService);

            session.Insert(ruleData);

            session.Fire();

            if (_arithmeticService.IsDNumberSet)
                return Json(_arithmeticService.DNumber);
            else
                return Json(_arithmeticService.INumber);
        }
    }

    
    public class RuleData
    {

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public string CodeTextString { get; set; }
        public string RuleString { get; set; }
        public string[] DataStringArray { get; set; }
        public double[] a { get; set; }

        public void ConvertStringArrayToNumberArray()
        {
            var arrayLength = 0;

            if (DataStringArray != null)
                arrayLength = DataStringArray.Count();

            if (a == null)
                a = new double[arrayLength];

            if (arrayLength == 0)
                return;

            for (int i = 0; i < DataStringArray.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(DataStringArray[i]))
                    continue;

                var dataString = DataStringArray[i];

                double d;
                double.TryParse(dataString, out d);
                a[i] = d;
            }
        }
    }
}

