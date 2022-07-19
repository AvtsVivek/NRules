using RulesAndModels.Models;
using System;
using NRules.Fluent.Dsl;

namespace RulesAndModels.Rules
{
    public class MalePersonRule : Rule
    {
        public override void Define()
        {
            Person person = null;

            When()
                .Match<Person>(() => person, c => c.IsMale);

            Then()
                .Do(ctx => PrintPersonName(person));
        }

        private static void PrintPersonName(Person person)
        {
            Console.WriteLine(person.Name);
        }
    }    
}
