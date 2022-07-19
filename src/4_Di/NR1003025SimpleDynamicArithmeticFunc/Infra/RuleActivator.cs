using Autofac;
using NRules.Fluent;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;

namespace NR1003025SimpleDynamicArithmeticFunc.Infra
{
    public class RuleActivator : IRuleActivator
    {
        private readonly ILifetimeScope _scope;

        public RuleActivator(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IEnumerable<Rule> Activate(Type type)
        {
            yield return (Rule)_scope.Resolve(type);
        }
    }
}
