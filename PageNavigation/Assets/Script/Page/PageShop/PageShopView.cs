using Script.Base.Page;

namespace Script.Page.PageShop
{
    public class PageShopView :  ViewBase, IPageShopView
    {
        private IPageShopViewMessage _message;
        public void SetViewMessage(IPageShopViewMessage message)
        {
            _message = message;
        }
    }
}
