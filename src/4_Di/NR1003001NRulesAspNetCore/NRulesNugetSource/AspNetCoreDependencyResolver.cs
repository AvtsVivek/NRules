using Microsoft.Extensions.DependencyInjection;
using NRules.Extensibility;
using System;

namespace NR1003001NRulesAspNetCore.NRulesNugetSource
{
    public class AspNetCoreDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _container;

        public AspNetCoreDependencyResolver(IServiceProvider serviceProvider)
        {
            _container = serviceProvider;
        }
        public object Resolve(IResolutionContext context, Type serviceType)
        {
            var serviceObject = _container.GetRequiredService(serviceType);
            return serviceObject;
        }
    }
}
