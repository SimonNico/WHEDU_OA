using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace WHEDU_OA_WEBAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            container.LoadConfiguration(configuration,"OAContainer");

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
         
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
     
    }
}