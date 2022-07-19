using NRules;
using NRules.RuleSharp;
using RulesAndModels.Models;
using System;
using System.Linq;

namespace NR1002001LoadRulesFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The example is from the following.");
            Console.WriteLine("https://stackoverflow.com/a/65745137/1977871");
            //Load rules
            var repository = new RuleRepository();


            repository.AddNamespace("System");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            repository.AddReference(typeof(Console).Assembly);
            repository.AddReference(typeof(Guest).Assembly);

            var ruleSets = repository.GetRuleSets().ToList();

            var rules = repository.GetRules().ToList();

            Console.WriteLine($"ruleSets.Count value is {ruleSets.Count}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Name value is {ruleSets.FirstOrDefault().Name}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules value is  {ruleSets.FirstOrDefault().Rules}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules.Count() value is {ruleSets.FirstOrDefault().Rules.Count()}");

            Console.WriteLine($"rules.Count value is {rules.Count}");

            //Load rule files
            repository.Load(@"MyRuleFile.txt");

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

            var guest1 = new Guest() { Name = "Lightning McQueen" };

            var guest2 = new Guest() { Name = "Hee", Email = @"email@gmail.com" };

            var guest3 = new Guest() { Name = "Hooo" };

            //Insert facts into the session
            session.Insert(guest1);
            session.Insert(guest2);
            session.Insert(guest3);

            //Fire rules
            session.Fire();
        }
    }
}
