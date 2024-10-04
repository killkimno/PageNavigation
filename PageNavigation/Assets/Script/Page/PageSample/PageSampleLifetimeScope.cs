using Script.Base.Page.Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Page.PageSample
{
    public class PageSampleLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private PageSampleView _view;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PageSamplePresenter>(Lifetime.Scoped).As<IPresenter>();
            builder.RegisterComponent<PageSampleView>(_view).AsImplementedInterfaces();
        }
    }
}
