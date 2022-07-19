using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Services
{
    public interface IArithmeticService {
        int INumber { get; set; }
        bool IsINumberSet { get; set; }
        double DNumber { get; set; }
        bool IsDNumberSet { get; set; }
        void ArithmeticOperation(int iNumber);
        void ArithmeticOperation(double dNumber);
    }
    public class ArithmeticService : IArithmeticService
    {
        public int INumber { get; set; }
        public double DNumber { get; set; }
        public bool IsINumberSet { get; set; }
        public bool IsDNumberSet { get; set; }

        public void ArithmeticOperation(int iNumber)
        {
            IsINumberSet = true; 
            INumber = iNumber;
        }
        public void ArithmeticOperation(double dNumber)
        {
            IsDNumberSet = true;
            DNumber = dNumber;
        }
    }
}
