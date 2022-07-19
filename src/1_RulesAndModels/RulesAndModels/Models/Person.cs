using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Models
{
    public class Person
    {
        public Person(bool isMale, string name)
        {
            IsMale = isMale;
            Name = name;
        }
        public bool IsMale { get; }
        public string Name { get; }
    }
}
