using MovieSample.Persistency.DataContext;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;


namespace MovieSample
{
    public static class UnityConfig
    {
        public static void Register(UnityContainer container)
        {
            RegisterResolvers(container);
            RegisterDataComponents(container);
        }

        private static void RegisterResolvers(UnityContainer container)
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterDataComponents(UnityContainer container)
        {
            container.RegisterType(typeof(IMovieContext), typeof(MovieContext));
            container.RegisterType(typeof(IMovieService), typeof(MovieService));
            //container.RegisterType<IMovieContext, MovieContext>(new PerRequestLifetimeManager(),
            //    new InjectionConstructor("name=MovieDbConnection");
            //container.RegisterType<IMovieService, MovieService>(new PerRequestLifetimeManager());
        }
    }
}