using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public bool IsPreferred { get; set; }
    }

    public class Order
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsDiscounted { get { return PercentDiscount > 0; } }

        public double Price
        {
            get { return UnitPrice * Quantity * (1.0 - PercentDiscount / 100.0); }
        }
    }
}
