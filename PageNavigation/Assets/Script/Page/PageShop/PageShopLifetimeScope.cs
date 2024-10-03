using Script.Base.Page;
using Script.Base.Page.Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Page.PageShop
{
    public class PageShopLifetimeScope :LifetimeScope
    {
        [SerializeField]
        private PageShopView _view;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PageShopPresenter>(Lifetime.Scoped).As<IPresenter>();
            builder.RegisterComponent<PageShopView>(_view).AsImplementedInterfaces();
        }
    }
}
