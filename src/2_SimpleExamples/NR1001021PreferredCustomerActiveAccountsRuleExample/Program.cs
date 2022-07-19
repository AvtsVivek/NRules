using NRules;
using NRules.Fluent;
using RulesAndModels.Models;
using RulesAndModels.Rules;
using System;
using System.Linq;

namespace NR1001021PreferredCustomerActiveAccountsRuleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // This example is from the following link.
            // https://github.com/NRules/NRules/wiki/Fluent-Rules-DSL#matching-facts-with-patterns

            Console.WriteLine("Hello World!");
            Console.WriteLine($"This is from the following link.");
            Console.WriteLine($"https://github.com/NRules/NRules/wiki/Fluent-Rules-DSL#matching-facts-with-patterns");

            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(PreferredCustomerActiveAccountsRule).Assembly)
            .Where(rule => rule.Name.Contains(nameof(PreferredCustomerActiveAccountsRule)))
            );

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            var bc1 = new CompanyCustomer("Narasimha") { IsPreferred = true };
            var bc2 = new CompanyCustomer("Surya") { IsPreferred = false };
            var bc3 = new CompanyCustomer("Venkata") { IsPreferred = true };
            var bc4 = new CompanyCustomer("Ganesha") { IsPreferred = false };

            var ba1 = new BankAccount(1234, bc1, true);
            var ba2 = new BankAccount(1235, bc2, false);
            var ba3 = new BankAccount(1236, bc3, false);
            
            session.Insert(bc1);
            session.Insert(bc2);
            session.Insert(bc3);
            session.Insert(bc4);
            session.Insert(ba1);
            session.Insert(ba2);
            session.Insert(ba3);

            session.Fire();
        }
    }
}
