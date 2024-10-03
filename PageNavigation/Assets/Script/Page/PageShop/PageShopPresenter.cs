using Script.Base.Navigator;
using Script.Base.Page;

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
