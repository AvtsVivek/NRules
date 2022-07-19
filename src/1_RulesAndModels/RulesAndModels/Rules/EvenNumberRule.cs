using RulesAndModels.Models;
using System;
using NRules.Fluent.Dsl;

namespace RulesAndModels.Rules
{
    public class EvenNumberRule : Rule
    {
        public override void Define()
        {
            int intNumber = 0;

            When()
                .Match<int>(() => intNumber, number => IsEvenNumber(number));

            Then()
                .Do(ctx => PrintInteger(intNumber));
        }

        private static void PrintInteger(int number)
        {
            Console.WriteLine(number);
        }

        public static bool IsEvenNumber(int intNumber)
        {
            if (intNumber % 2 == 0)
                return true;
            else
                return false;
        }
    }

    //public static class IntExtensionNumbers
    //{
    //    public static bool IsEvenNumber(this int intNumber)
    //    {
    //        if (intNumber % 2 == 0)
    //            return true;
    //        else
    //            return false;
    //    }
    //}
}
