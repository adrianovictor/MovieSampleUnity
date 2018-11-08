using System;
using System.Threading.Tasks;
using Castle.Windsor;
using Microsoft.Owin;
using Owin;
using Unity;

[assembly: OwinStartup(typeof(MovieSample.Startup))]
namespace MovieSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var container = new UnityContainer();
            //UnityConfig.Register(container);
            var container = new WindsorContainer();
            WindsorConfig.Register(container);
        }
    }
}
