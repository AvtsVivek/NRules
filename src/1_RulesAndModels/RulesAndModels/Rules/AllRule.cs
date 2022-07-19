using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Utilities;

namespace RulesAndModels.Rules
{
    public class AllRule : Rule
    {
        public AllRule()
        {

        }

        public override void Define()
        {
            CompanyCustomer customer = null;

            When()
                .Match<CompanyCustomer>(() => customer, c => c.IsPreferred)
                .All<BankAccount>(a => a.AccountOwner == customer, a => a.IsActive);

            Then()
                .Do(ctx => UtilityPrintMethods.PrintCompanyCustomer(customer));
        }
    }
}

// c.IsPreferred && (a.AccountOwner == customer && a => a.IsActive && ... you can have as many conditions as you want.)
