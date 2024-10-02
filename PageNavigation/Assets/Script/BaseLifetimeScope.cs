using Assets.Script.Base.Navigator;
using VContainer;
using VContainer.Unity;

namespace Assets.Script
{
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegistPages(builder);
            builder.Register<PageNavigator>(Lifetime.Singleton);
            builder.Register<PageResourceMapper>(Lifetime.Singleton);
            builder.Register<SampleStarter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<SampleStarter>();
        }

        private void RegistPages(IContainerBuilder builder)
        {

        }
    }
}

