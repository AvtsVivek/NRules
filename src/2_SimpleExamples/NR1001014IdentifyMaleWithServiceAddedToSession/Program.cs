using NRules;
using NRules.Fluent;
using RulesAndModels.Models;
using RulesAndModels.Rules;
using RulesAndModels.Services;
using System;
using System.Linq;

namespace NR1001014IdentifyMaleWithServiceAddedToSession
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var startupMessage = $"This demonstrates a way to inject services into the a given rule." + Environment.NewLine + 
                $"Here we are creating an instance of a service and adding it to the session." + Environment.NewLine +
                $"Then the rule will use that service in the Do method." + Environment.NewLine +
                $"The other way is to inject dependencies into the rules." + Environment.NewLine +
                $"This is demonstrated in web applications in the folder 4_Di. " + Environment.NewLine;

            Console.WriteLine(startupMessage);


            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(MalePersonRuleWithServiceAddedToSession).Assembly)
            .Where(rule => rule.Name.Contains(nameof(MalePersonRuleWithServiceAddedToSession)))
            );

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            var personService = new PersonService();

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

            session.Insert(personService);

            session.Fire();

            var people = personService.GetPeople();

            people.ToList().ForEach(p => Console.WriteLine(p.Name));
        }
    }
}
