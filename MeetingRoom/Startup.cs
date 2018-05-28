using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingRoom.Startup))]
namespace MeetingRoom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
