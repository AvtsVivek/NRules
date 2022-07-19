using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Models
{
    public class BankAccount
    {
        public BankAccount(int accountId, CompanyCustomer companyCustomer, bool isActive)
        {
            AccountOwner = companyCustomer;
            AccountId = accountId;
            IsActive = isActive;
        }
        public int AccountId { get; }
        public CompanyCustomer AccountOwner { get; }
        public bool IsActive { get; set; }
    }
}
