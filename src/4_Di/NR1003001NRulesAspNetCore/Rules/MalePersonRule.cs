using NR1003001NRulesAspNetCore.Models;
using NR1003001NRulesAspNetCore.Services;
using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using System;
using System.Diagnostics;

namespace NR1003001NRulesAspNetCore.Rules
{
    public class MalePersonRule : Rule
    {
        public MalePersonRule()
        {
            //Debugger.Break();

            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameof(MalePersonRule)} object is created.");
            Console.ForegroundColor = defaultColor;
        }
        //private readonly IPersonService _personService;

        //public MalePersonRule(IPrintService printService
        //    , IPersonService personService
        //    )
        //{
        //    Debugger.Break();
        //    _personService = personService;
        //}

        public override void Define()
        {
            IPersonService personService = null;
                        

            Dependency()
                .Resolve(() => personService);

            Person person = null;

            When()
                .Match<Person>(() => person, c => c.IsMale);

            Then()
                .Do(ctx => Console.WriteLine(personService.Id + " " + person.Name))
                .Do(ctx => personService.AddPersonInfo(person));
        }
    }
}
