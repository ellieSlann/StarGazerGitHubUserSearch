using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BGL.Net.StarGazerGitHubSearch.DataAccess;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace BGL.Net.StarGazerGitHubSearch
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //static readonly Container container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 1. Create a new Simple Injector container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // 2. Configure the container (register)
            container.Register<IApiClient, ApiClient>(Lifestyle.Transient);
            container.Register<IHttpClientWrapper, HttpClientWrapper>(Lifestyle.Transient);
            container.Register<IUserModelBuilder, UserModelBuilder>(Lifestyle.Transient);

           container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // 3. Verify your configuration
            container.Verify();

            //4. store the container for use by the application
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
