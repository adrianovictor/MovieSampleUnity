using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MovieSample.Common.Web.IoC.Windsor;
using MovieSample.Controllers;
using MovieSample.Persistency.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieSample
{
    public class WindsorConfig
    {
        public static void Register(IWindsorContainer container)
        {
            RegisterInstallers(container);
            RegisterControllers(container);
            RegisterDataComponents(container);
        }

        private static void RegisterInstallers(IWindsorContainer container)
        {
            container.Install(FromAssembly.InDirectory(new AssemblyFilter("bin")
                .FilterByAssembly(c => c.FullName.StartsWith("MovieSample", StringComparison.CurrentCultureIgnoreCase))));
        }

        private static void RegisterControllers(IWindsorContainer container)
        {
            container.Register(Classes.FromAssembly(typeof(HomeController).Assembly)
                .BasedOn<IController>()
                .If(c => c.Name.EndsWith("Controller"))
                .Configure(c => c.LifeStyle.HybridPerWebRequestTransient()));

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }

        private static void RegisterDataComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IMovieContext>().Named("data.context").ImplementedBy<MovieContext>().LifeStyle.Singleton.OnlyNewServices());
            container.Register(Component.For<IMovieService>().ImplementedBy<MovieService>().LifeStyle.HybridPerWebRequestTransient().OnlyNewServices());
        }
    }
}