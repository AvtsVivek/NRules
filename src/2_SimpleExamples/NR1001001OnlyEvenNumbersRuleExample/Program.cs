using NRules;
using NRules.Fluent;
using RulesAndModels.Models;
using RulesAndModels.Rules;
using System;
using System.Linq;

namespace NR1001001OnlyEvenNumbersRuleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EvenNumberRule!");

            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(EvenNumberRule).Assembly)
            .Where(rule => rule.Name.Contains(nameof(EvenNumberRule)))
            );

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            session.Insert(12);
            session.Insert(13);
            session.Insert(14);
            session.Insert(15);
            session.Insert(16);

            session.Fire();
        }
    }
}
