using Autofac;
using NR1003009DynamicNRules.Models;
using NR1003009DynamicNRules.Services;
using NRules;
using NRules.Fluent;
using NRules.RuleModel;
using RulesAndModels.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
//using System.Reflection;

namespace NR1003009DynamicNRules.Infra
{
    public class RulesEngineModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
                .OnActivating(e => e.Instance.Load(x => x.From(types)))
                //.OnActivating(e => e.Instance.Load(x => x.From(assemblies)))
                .PropertiesAutowired();

            builder.RegisterType<RuleSharpRepository>()
                .As<IRuleSharpRepository>().SingleInstance();

            builder.Register(c => c.Resolve<IRuleRepository>().Compile())
                .As<ISessionFactory>().SingleInstance()
                .OnActivating(e => new RulesEngineLogger(e.Instance))
                .PropertiesAutowired()
                .AutoActivate();

            builder.Register(c => c.Resolve<ISessionFactory>().CreateSession())
                .As<ISession>().InstancePerLifetimeScope();
        }
    }
}
