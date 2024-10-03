using Script.Base.Page;
using Script.Base.Page.View;

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
