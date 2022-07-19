using NRules;
using NRules.RuleSharp;
using RulesAndModels.Models;
using RulesAndModels.Services;
using System;
using System.Linq;

namespace NR1002041MalePersonRuleWithServiceAddedToSessionTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load rules
            var repository = new RuleRepository();

            repository.AddNamespace("System");
            repository.AddNamespace("RulesAndModels.Services");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            repository.AddReference(typeof(Console).Assembly);
            repository.AddReference(typeof(Person).Assembly);

            //Load rule files
            repository.Load(@"MalePersonRule.txt");

            var personService = new PersonService();

            //Compile rules 
            var factory = repository.Compile();

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

            session.Insert(personService);

            //Fire rules
            session.Fire();

            var people = personService.GetPeople();

            people.ToList().ForEach(p => Console.WriteLine(p.Name));
        }
    }
}
