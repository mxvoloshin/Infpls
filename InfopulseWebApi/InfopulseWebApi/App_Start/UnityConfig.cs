using System.Web.Http;
using Infopulse.EntityFramework.Repository;
using InfopulseWebApi.Services;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace InfopulseWebApi.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType(typeof(IRepository<,>), typeof(Repository<,>));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}