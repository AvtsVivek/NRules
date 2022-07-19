using NRules;
using NRules.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NR1003009DynamicNRules.Infra
{
    internal class RulesEngineLogger
    {
        public RulesEngineLogger(ISessionFactory sessionFactory)
        {
            sessionFactory.Events.RuleFiredEvent += OnRuleFired;
            sessionFactory.Events.LhsExpressionFailedEvent += OnConditionFailedEvent;
            sessionFactory.Events.RhsExpressionFailedEvent += OnActionFailedEvent;
            
        }

        private void OnRuleFired(object sender, AgendaEventArgs args)
        {
            Console.WriteLine($"Rule fired. Rule={args.Rule.Name}");
        }

        private void OnConditionFailedEvent(object sender, LhsExpressionErrorEventArgs args)
        {
            Console.WriteLine($"Condition evaluation failed. Condition={args.Expression}, Message={args.Exception}");
        }

        private void OnActionFailedEvent(object sender, RhsExpressionErrorEventArgs args)
        {
            Console.WriteLine($"Action evaluation failed. Action={args.Expression}, Message={args.Exception}");
        }
    }
}
