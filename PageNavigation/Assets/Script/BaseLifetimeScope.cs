using Script.Base.Navigator;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script
{
    public class BaseLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private Transform _disableRoot;

        [SerializeField]
        private PageRoot _pageRoot;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_pageRoot);
            builder.RegisterComponent(_disableRoot);
            builder.Register<PageNavigator>(Lifetime.Singleton);
            builder.Register<PageResourceMapper>(Lifetime.Singleton);
            builder.Register<SampleStarter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<SampleStarter>();
        }
    }
}
