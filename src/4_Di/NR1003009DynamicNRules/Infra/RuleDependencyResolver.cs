using System;
using Autofac;
using NRules.Extensibility;

namespace NR1003009DynamicNRules.Infra
{
    public class RuleDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _scope;

        public RuleDependencyResolver(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public object Resolve(IResolutionContext context, Type serviceType)
        {
            return _scope.Resolve(serviceType);
        }
    }
}
