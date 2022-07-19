using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Utilities;


namespace RulesAndModels.Rules
{
    public class NotRule : Rule
    {
        public NotRule()
        {

        }
        public override void Define()
        {
            CompanyCustomer customer = null;

            When()
                .Match<CompanyCustomer>(() => customer, c => c.IsPreferred)
                .Not<BankAccount>(a => a.AccountOwner == customer, a => a.IsActive);

            Then()
                .Do(ctx => UtilityPrintMethods.PrintCompanyCustomer(customer));
        }
    }
}

// See below. The Exclamation mark is because of Not.
// c.IsPreferred && !(a.AccountOwner == customer && a => a.IsActive && ... you can have as many conditions as you want.)
