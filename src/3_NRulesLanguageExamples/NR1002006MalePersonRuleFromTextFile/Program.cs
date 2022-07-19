using NRules;
using NRules.RuleSharp;
using RulesAndModels.Models;
using System;
using System.Linq;

namespace NR1002006MalePersonRuleFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {

            //Load rules
            var repository = new RuleRepository();


            repository.AddNamespace("System");
            repository.AddNamespace("RulesAndModels.Utilities");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            repository.AddReference(typeof(Console).Assembly);
            repository.AddReference(typeof(Person).Assembly);

            var ruleSets = repository.GetRuleSets().ToList();

            var rules = repository.GetRules().ToList();

            Console.WriteLine($"ruleSets.Count value is {ruleSets.Count}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Name value is {ruleSets.FirstOrDefault().Name}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules value is  {ruleSets.FirstOrDefault().Rules}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules.Count() value is {ruleSets.FirstOrDefault().Rules.Count()}");

            Console.WriteLine($"rules.Count value is {rules.Count}");

            //Load rule files
            repository.Load(@"MalePersonRule.txt");

            Console.WriteLine($"ruleSets.Count value is {ruleSets.Count}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Name value is {ruleSets.FirstOrDefault().Name}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules value is  {ruleSets.FirstOrDefault().Rules}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules.Count() value is {ruleSets.FirstOrDefault().Rules.Count()}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules.FirstOrDefault().Name value is {ruleSets.FirstOrDefault().Rules.FirstOrDefault().Name}");

            Console.WriteLine($"rules.Count value is {rules.Count}");

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

            //Fire rules
            session.Fire();
        }
    }
}
