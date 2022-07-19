using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Models
{
    public class CompanyCustomer
    {
        public CompanyCustomer(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public bool IsPreferred { get; set; }
    }
}
