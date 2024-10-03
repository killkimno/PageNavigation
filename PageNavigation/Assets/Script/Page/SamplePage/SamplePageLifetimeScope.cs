using Script.Base.Page;
using Script.Base.Page.Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Page.SamplePage
{
    public class SamplePageLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private SamplePageView _view;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SamplePagePresenter>(Lifetime.Scoped).As<IPresenter>();
            builder.RegisterComponent<SamplePageView>(_view).AsImplementedInterfaces();
        }
    }
}
