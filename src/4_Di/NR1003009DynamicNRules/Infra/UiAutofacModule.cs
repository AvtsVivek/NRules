using Autofac;
using NR1003009DynamicNRules.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NR1003009DynamicNRules.Infra
{
    public class UiAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Add any services registrations.
            // Register the services to be decorated.
            builder.RegisterType<MyService>().As<IService>();

            // Then register the decorator. You can register multiple
            // decorators and they'll be applied in the order that you
            // register them. In this example, all IService
            // will be decorated with logging and ExceptionHandling decorators.

            builder.RegisterDecorator<MyLoggingService, IService>();
            builder.RegisterDecorator<MyExceptionHandlingService, IService>();

            

            base.Load(builder);
        }
    }
}
