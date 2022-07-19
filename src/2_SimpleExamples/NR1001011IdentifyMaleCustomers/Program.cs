using NRules;
using NRules.Fluent;
using RulesAndModels.Models;
using RulesAndModels.Rules;
using System;
using System.Linq;

namespace NR1001011IdentifyMaleCustomers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(MalePersonRule).Assembly)
            .Where(rule => rule.Name.Contains(nameof(MalePersonRule)))
            );

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            var p1 = new Person(true, "Person1");
            var p2 = new Person(false, "Person2");
            var p3 = new Person(true, "Person3");
            var p4 = new Person(true, "Person4");
            var p5 = new Person(false, "Person5");
            var p6 = new Person(true, "Person6");

            session.Insert(p1);
            session.Insert(p2);
            session.Insert(p3);
            session.Insert(p4);
            session.Insert(p5);
            session.Insert(p6);

            session.Fire();
        }
    }
}
