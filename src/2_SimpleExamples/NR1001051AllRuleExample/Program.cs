﻿using NRules;
using NRules.Fluent;
using RulesAndModels.Models;
using RulesAndModels.Rules;
using System;
using System.Linq;

namespace NR1001051AllRuleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All rule example.! Universal Quantifier");
            Console.WriteLine($"This is from the following link.");
            Console.WriteLine($"https://github.com/NRules/NRules/wiki/Fluent-Rules-DSL#universal-quantifier");

            //Load rules
            var repository = new RuleRepository();
            
            repository.Load(x => x.From(typeof(AllRule).Assembly)
            .Where(rule => rule.Name.Contains(nameof(AllRule)))
            );

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
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

            session.Fire();
        }
    }
}
