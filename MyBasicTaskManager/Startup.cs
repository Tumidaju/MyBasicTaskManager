using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBasicTaskManager.Startup))]
namespace MyBasicTaskManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
