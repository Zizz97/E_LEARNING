using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ELearningPlatforma.Startup))]
namespace ELearningPlatforma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
