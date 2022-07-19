using NR1003005NRulesWithAutofacGulpAndNPM.Services;
using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Services;
using System;
using System.Collections.Generic;

namespace NR1003005NRulesWithAutofacGulpAndNPM.Rules
{
    public class MalePersonRule : Rule
    {
        private readonly IPrintService _printService;
        public MalePersonRule(IPrintService printService)
        {
            _printService = printService;
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameof(MalePersonRule)} object is created.");
            Console.ForegroundColor = defaultColor;
        }

        public override void Define()
        {
            
            IPersonService personService = null;
            Dependency().Resolve(() => personService);

            Person person = null;
            List<double> numberData = null;

            When()
                .Match<Person>(() => person, c => c.IsMale)
                //.Match<SomeArrayWrapper>(() => someArrayWrapper, c => true)
                .Match<List<double>>(() => numberData, c => true)
                ;

            Then()
                .Do(ctx => _printService.PrintPerson(person))
                .Do(ctx => Console.WriteLine(personService.Id + " " + person.Name))
                .Do(ctx => personService.AddPersonInfo(person))
                .Do(ctx => Console.WriteLine(numberData[0]))
                ;
        }
    }

    // Note 1.
    // A rule is instanciated by rule activator. 
    // Rule activator is a property on RuleRepository class.
    // In this example, RuleActivator is explicitly defined by a class 
    // implimenting IRuleActivator.
    // This rule activator is simply a wrapper to autofac container.
    // 
    // Note 2. 
    // All rules are instanciated right at the time of registration.
    // This is in the very early stages in the app life cycle. 
    // Specifically this happens when Rule Repository is being activated.
    // Immediately after the rule repository is instanciated, it instanciates all the rules 
    // it knows about. If a rule activator is assigned, 
    // then this activator is used, as in this example case.
    // If the rule activator is not assigned, then repository instanciates rule classes 
    // by itself. In such a case, for every rule, a parameter less ctor is needed.
    // If a rule is defined without a paramterless ctor, then an exception is thrown by the 
    // rule repository.
    // So its better we use a rule activator. 
    // In a case where a Rule has a dependency declared by the ctor itself, then 
    // a rule activator becomes necessary.
    // 
    // Note 3. 
    // Declaring dependencies by declaring in the ctor is not advised.
    // This is because, the rules themselves are single ton objects. So 
    // If a rule has dependencies declared in the ctor, then the dependencies 
    // must also be singleton. In such a case, the dependencies cannot have relation with 
    // with request life cycle. 
    // If the dependencies are not supposed to be singleton, then they must be resolved
    // as follows in the Define method of the Rule.
    // IPersonService personService = null;
    // Dependency().Resolve(() => personService);
    // 

}
