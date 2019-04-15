using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using System.Data.Entity;
using System.Web.Http;

namespace AccessCorpFormulario.Apresentation.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new AccessCorpInitializer());
        }
    }
}
