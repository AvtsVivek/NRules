using NRules;
using NRules.RuleSharp;
using RulesAndModels.Models;
using System;
using System.Linq;

namespace NR1002003PreferredCustomerDiscountRuleFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The example is from the following.");
            Console.WriteLine("https://github.com/NRules/NRules.Language#getting-started");
            //Load rules
            var repository = new RuleRepository();


            repository.AddNamespace("System");

            //Add references to any assembly that the rules are using, e.g. the assembly with the domain model
            repository.AddReference(typeof(Console).Assembly);
            repository.AddReference(typeof(Customer).Assembly);

            var ruleSets = repository.GetRuleSets().ToList();

            var rules = repository.GetRules().ToList();

            Console.WriteLine($"ruleSets.Count value is {ruleSets.Count}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Name value is {ruleSets.FirstOrDefault().Name}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules value is  {ruleSets.FirstOrDefault().Rules}");

            Console.WriteLine($"ruleSets.FirstOrDefault().Rules.Count() value is {ruleSets.FirstOrDefault().Rules.Count()}");

            Console.WriteLine($"rules.Count value is {rules.Count}");

            //Load rule files
            repository.Load(@"OrderDiscountRule.txt");

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

            var customer = new Customer { Name = "John Doe", IsPreferred = true };
            var order1 = new Order { Quantity = 12, UnitPrice = 10.0 };
            var order2 = new Order { Quantity = 5, UnitPrice = 15.0 };

            //Insert facts into the session
            session.Insert(customer);
            session.InsertAll(new[] { order1, order2 });

            //Fire rules
            session.Fire();
        }
    }
}
