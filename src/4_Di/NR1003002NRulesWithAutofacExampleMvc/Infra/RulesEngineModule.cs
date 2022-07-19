using Autofac;
using NR1003002NRulesWithAutofacExampleMvc.Models;
using NR1003002NRulesWithAutofacExampleMvc.Services;
using NRules;
using NRules.Fluent;
using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Reflection;
//using System.Reflection;

namespace NR1003002NRulesWithAutofacExampleMvc.Infra
{
    public class RulesEngineModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Assembly[] assemblies = new List<Assembly>().ToArray();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();


            builder.RegisterType<PersonService>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<RuleDependencyResolver>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<RuleActivator>()
                .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<RuleDependencyResolver>()
                .AsImplementedInterfaces().InstancePerDependency();

            var scanner = new RuleTypeScanner();
            scanner.AssemblyOf(this.GetType());

            var types = scanner.GetRuleTypes();

            builder.RegisterTypes(types).AsSelf();

            builder.RegisterType<RuleRepository>()
                .AsImplementedInterfaces().SingleInstance()
                //.OnActivating(e => e.Instance.Load(x => x.From(types)))
                .OnActivating(e => e.Instance.Load(x => x.From(assemblies)))
                .PropertiesAutowired();

            builder.Register(c => c.Resolve<IRuleRepository>().Compile())
                .As<ISessionFactory>().SingleInstance()
                .OnActivating(e => new RulesEngineLogger(e.Instance))
                .PropertiesAutowired()
                .AutoActivate();

            builder.Register(c => c.Resolve<ISessionFactory>().CreateSession())
                .As<ISession>().InstancePerLifetimeScope();

            //return services.AddScoped<ISession>(c => services.BuildServiceProvider().GetRequiredService<ISessionFactory>().CreateSession());
        }
    }
}
