using NR1003002NRulesWithAutofacExampleMvc.Models;
using RulesAndModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NR1003002NRulesWithAutofacExampleMvc.Services
{
    public interface IPrintService {
        public void PrintPerson(Person person);
    }
    public class PrintService : IPrintService
    {
        public void PrintPerson(Person person)
        {
            Console.WriteLine(person.Name);
        }
    }
}
