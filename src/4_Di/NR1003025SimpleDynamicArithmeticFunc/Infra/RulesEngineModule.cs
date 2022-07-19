using Autofac;
using NRules;
using NRules.Fluent;
using RulesAndModels.Services;
using System;
using System.Reflection;
//using System.Reflection;

namespace NR1003025SimpleDynamicArithmeticFunc.Infra
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

            //builder.RegisterType<RuleRepository>()            // Notes 1234562
            //    .AsImplementedInterfaces().SingleInstance()
            //    .OnActivating(e => e.Instance.Load(x => x.From(types)))
            //    //.OnActivating(e => e.Instance.Load(x => x.From(assemblies)))
            //    .PropertiesAutowired();

            builder.RegisterType<RuleSharpRepository>()
                .As<IRuleSharpRepository>()
                .InstancePerLifetimeScope();                    // Notes 1234561

            builder.Register(c => c.Resolve<IRuleSharpRepository>().Compile())
                .As<ISessionFactory>().SingleInstance()
                .OnActivating(e => new RulesEngineLogger(e.Instance))
                .PropertiesAutowired()
                .AutoActivate();

            builder.Register(c => c.Resolve<ISessionFactory>().CreateSession())
                .As<ISession>().InstancePerLifetimeScope();
        }
    }
}

// Notes 1234561
// Earlier this was SingleInstance(). I had to change that to 
// InstancePerLifetimeScope(). When it was singleton, the CreateSession 
// var session = factory.CreateSession(); 
// method call does not seem to create a new sesssion.
// It appears, the facts inserted in the previouos session remain. They are not getting cleaned up.
// Even after Retract method call on the session object, they remain. Looks like this is a bug.
// So currently, its better make the repository itself transient in the requst scope.

// Notes 1234562 
// This is not currently needed for this app. We are using only dynamic rules.
// NRules.RuleSharp. 