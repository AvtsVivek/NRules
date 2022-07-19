using NR1003005NRulesWithAutofacGulpAndNPM.Models;
using RulesAndModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NR1003005NRulesWithAutofacGulpAndNPM.Services
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
