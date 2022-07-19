using Microsoft.AspNetCore.Http;
using NRules;
using NRules.Extensibility;
using System.Threading.Tasks;

namespace NR1003005NRulesWithAutofacGulpAndNPM.MiddleWare
{
    public class NRulesMiddleWare
    {
        private readonly RequestDelegate _next;

        public NRulesMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,
            ISessionFactory sessionFactory, IDependencyResolver dependencyResolver)
        {
            // Reference: https://stackoverflow.com/a/48591356/1977871
            // Note 1. sessionFactory object is singleton meaning, its created at the start of the object
            // Then its the same instance is used throughout the applicatioin life cycle.
            // But then the dependency resolver needs to be assigned everytime a request arrives.
            // If dependencyResolver is assigned rigth in the beginning at the time of registration of 
            // sessionFactory, then its not working. Not sure why.
            // Note 2. Here the dependency resolver instance is assigned afresh for each request.
            sessionFactory.DependencyResolver = dependencyResolver;
            await _next.Invoke(context);
        }
    }

}
