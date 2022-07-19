using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NRules.Fluent.Dsl;
using NRules.Fluent;
using System.Linq;
using System.Reflection;
using NRules.RuleModel;
using NRules;
using NR1003001NRulesAspNetCore.Services;

namespace NR1003001NRulesAspNetCore.NRulesNugetSource
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseNRules(this IApplicationBuilder app)
        {
            var repo = app.ApplicationServices.GetService<RuleRepository>();

            if (repo == null)
                throw new InvalidOperationException("Dependencies not registered. Call AddNRules in Startup.cs");

            //repo.Activator = new AspNetCoreRuleActivator(app.ApplicationServices);

            return app;
        }
    }
}