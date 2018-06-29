using System.Web.Http;
using Unity;
using Unity.WebApi;
using Microsoft.Practices.Unity.Configuration;

using System.Configuration;

namespace WHEDU_OA_WEBAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configuration.Configure(container,"OAContainer");
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}