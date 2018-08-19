using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeApp.WebMVC.Startup))]
namespace RecipeApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
