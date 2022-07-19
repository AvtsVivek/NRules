using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Utilities;

namespace RulesAndModels.Rules
{
    public class PreferredCustomerActiveAccountsRule : Rule
    {
        public PreferredCustomerActiveAccountsRule()
        {

        }

        public override void Define()
        {
            CompanyCustomer customer = null;
            BankAccount account = null;

            When()
                .Match<CompanyCustomer>(() => customer, c => c.IsPreferred)
                .Match<BankAccount>(() => account, a => a.AccountOwner == customer, a => a.IsActive);

            Then()
                .Do(ctx => UtilityPrintMethods.PrintCompanyCustomer(customer));
        }
    }
}

// c.IsPreferred && then match also (a.AccountOwner == customer && a => a.IsActive && ... you can have as many conditions as you want.)
