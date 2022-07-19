using Microsoft.Extensions.DependencyInjection;
using NRules;
using NRules.Extensibility;
using NRules.Fluent;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NR1003001NRulesAspNetCore.NRulesNugetSource
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNRules(this IServiceCollection services, Assembly[] assemblies)
        {
            services.RegisterRepository(r =>
                      {
                          r.Load(x => x.From(services.AddRules(assemblies)));
                      })
                    .RegisterFactory()
                    .RegisterSession();

            return services;
        }

        #region Rules

        private static Type[] AddRules(this IServiceCollection services, Assembly[] assemblies)
        {
            var scanner = new RuleTypeScanner();

            scanner.Assembly(assemblies);
            var ruleTypes = scanner.GetRuleTypes();

            services.AddManyScoped(ruleTypes);

            return ruleTypes;
        }

        #endregion

        #region Repository 
        private static IServiceCollection RegisterRepository(this IServiceCollection services, Action<RuleRepository> initAction)
        {
            var ruleRepo = new RuleRepository();
            ruleRepo.Activator = new AspNetCoreRuleActivator(services.BuildServiceProvider());
            
            initAction(ruleRepo);
            services.AddSingleton(ruleRepo);           

            return services;
        }
        #endregion

        #region Factory 
        private static IServiceCollection RegisterFactory(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var sessionFactory = serviceProvider.GetRequiredService<RuleRepository>().Compile();

            var ruleEngineLogger = new RulesEngineLogger(sessionFactory);

            return services.AddSingleton<ISessionFactory>(sessionFactory);
        }

        #endregion

        #region Session
        private static IServiceCollection RegisterSession(this IServiceCollection services)
        {

            return services.AddScoped<ISession>(c => services.BuildServiceProvider().GetRequiredService<ISessionFactory>().CreateSession());
        }

        #endregion
        private static IServiceCollection AddManyScoped(this IServiceCollection services, Type[] types)
        {

            for (int i = 0; i < types.Length; i++)
            {
                services.AddScoped(types[i]);
            }

            return services;
        }
    }
}
