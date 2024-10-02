using VContainer;
using VContainer.Unity;

namespace Assets.Script
{
    public class BaseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegistPages(builder);
            builder.Register<SampleStarter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<SampleStarter>();
        }

        private void RegistPages(IContainerBuilder builder)
        {

        }
    }
}

