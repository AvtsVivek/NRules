using NRules;
using NRules.RuleSharp;
using RulesAndModels.Models;
using System;
using System.Linq;

namespace NR1002012PreferredCustomerNotRuleFromTextFile
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
            repository.Load(@"CustomerWithoutNotRule.txt");

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

            var narasimha = new CompanyCustomer("Narasimha") { IsPreferred = true };
            var surya = new CompanyCustomer("Surya") { IsPreferred = false };
            var venkata = new CompanyCustomer("Venkata") { IsPreferred = true };
            var ganesha = new CompanyCustomer("Ganesha") { IsPreferred = false };
            var rama = new CompanyCustomer("Rama") { IsPreferred = true };
            var venu = new CompanyCustomer("Venu") { IsPreferred = true };

            var ba1 = new BankAccount(1234, narasimha, true);
            var ba2 = new BankAccount(1235, surya, false);
            var ba3 = new BankAccount(1236, venkata, false);
            var ba4 = new BankAccount(1237, rama, false);

            session.Insert(narasimha);
            session.Insert(surya);
            session.Insert(venkata);
            session.Insert(ganesha);
            session.Insert(rama);
            session.Insert(venu);


            session.Insert(ba1);
            session.Insert(ba2);
            session.Insert(ba3);
            session.Insert(ba4);

            //Fire rules
            session.Fire();
        }
    }
}
