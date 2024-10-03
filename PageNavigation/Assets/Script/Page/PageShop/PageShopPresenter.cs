using Script.Base.Navigator;
using Script.Base.Page;
using Script.Base.Page.Presenter;
using Script.Base.Page.View;

namespace Script.Page.PageShop
{
    [PrefabPath("Prefab/PageShop")]
    public class PageShopPresenter : BasePresenter, IPageShopViewMessage
    {
        private readonly IUIView _view;

        public PageShopPresenter(PageNavigator pageNavigator, IUIView view) : base(pageNavigator, view)
        {
            _view = view;
        }
    }
}
