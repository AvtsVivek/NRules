using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Rules
{
    // This rule picks out Preferred customer and also who has a bank active account
    public class ExistentialRule : Rule
    {
        public ExistentialRule()
        {

        }
        public override void Define()
        {
            CompanyCustomer customer = null;

            When()
                .Match<CompanyCustomer>(() => customer, c => c.IsPreferred)
                .Exists<BankAccount>(a => a.AccountOwner == customer, a => a.IsActive);

            Then()
                .Do(ctx => UtilityPrintMethods.PrintCompanyCustomer(customer));
        }
    }
}

// See below. 
// c.IsPreferred && (a.AccountOwner == customer && a => a.IsActive && ... you can have as many conditions as you want.)
// So in the Exists, even if one becomes true, the rule is fired.
