using RulesAndModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Utilities
{
    public class UtilityPrintMethods
    {
        public static void PrintCompanyCustomer(CompanyCustomer companyCustomer) 
        {
            Console.WriteLine(companyCustomer.Name);
        }

        public static void PrintPersonName(Person person)
        {
            Console.WriteLine($"The person with name {person.Name} is male person.");
        }
    }
}