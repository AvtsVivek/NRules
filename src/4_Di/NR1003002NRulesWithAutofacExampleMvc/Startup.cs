using Autofac;
using NR1003002NRulesWithAutofacExampleMvc.Infra;
using NR1003002NRulesWithAutofacExampleMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NR1003002NRulesWithAutofacExampleMvc.MiddleWare;

namespace NR1003002NRulesWithAutofacExampleMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddTransient<IPrintService, PrintService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseMiddleware<NRulesMiddleWare>();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Configure Container using Autofac: Register Dependency Injection.
        /// This is called AFTER ConfigureServices. Place breakpoints and see.
        /// So things you register here OVERRIDE things registered in ConfigureServices.
        /// You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())` in Program.cs
        /// when building the host. Otherwise this method will not be called. 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterModule(new UiAutofacModule());
            builder.RegisterAssemblyModules(typeof(RulesEngineModule).Assembly);

            builder.RegisterType<PrintService>().As<IPrintService>();
            
            // Add any services registrations.
            // Register the services to be decorated.

            //builder.RegisterType<MyService>().As<IService>();

            // Then register the decorator. You can register multiple
            // decorators and they'll be applied in the order that you
            // register them. In this example, all IService
            // will be decorated with logging and ExceptionHandling decorators.

            //builder.RegisterDecorator<MyLoggingService, IService>();
            //builder.RegisterDecorator<MyExceptionHandlingService, IService>();
        }
    }
}
