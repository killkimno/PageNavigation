using Script.Base.Page;
using Script.Base.Page.View;

namespace Script.Page.PageShop
{
    public interface IPageShopView : IUIView<IPageShopViewMessage>
    {
    }

    public interface IPageShopViewMessage
    {
        void OnClickBack();
    }

    public class PageShopParam : PageParam
    {

    }

    public class PageShopResult : PageResult
    {

    }
}
