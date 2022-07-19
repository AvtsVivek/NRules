//using NR1003005NRulesWithAutofacGulpAndNPM.Models;
//using RulesAndModels.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NR1003005NRulesWithAutofacGulpAndNPM.Services
//{
//    public interface IPersonService
//    {
//        public Guid Id { get; }
//        public void WritePersonInfo(Person person);
//        public void AddPersonInfo(Person person);
//        public Person[] GetPeople();

//    }
//    public class PersonService : IPersonService
//    {
//        public Guid Id { get; }

//        private List<Person> _people { get; set; }

//        public PersonService()
//        {
//            //Debugger.Break();
//            Id = Guid.NewGuid();
//            Console.WriteLine($"Person Service Created with Id {Id}");
//            _people = new List<Person>();
//        }

//        public void WritePersonInfo(Person person)
//        {
//            Console.WriteLine($"{person.Name} is male.");
//        }

//        public void AddPersonInfo(Person person)
//        {
//            _people.Add(person);
//        }

//        public Person[] GetPeople()
//        {
//            return _people.ToArray();
//        }
//    }
//}
