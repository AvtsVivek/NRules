using NRules.Fluent.Dsl;
using RulesAndModels.Models;
using RulesAndModels.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesAndModels.Rules
{
    public class MalePersonRuleWithServiceAddedToSession : Rule
    {
        public override void Define()
        {
            Person person = null;
            PersonService personService = null;
            When()
                .Match(() => person, c => c.IsMale)
                .Match(() => personService, c => true);

            Then()
                .Do(ctx => personService.AddPersonInfo(person));

        }
    }
}
