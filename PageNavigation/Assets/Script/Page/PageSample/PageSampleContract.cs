using Script.Base.Page;
using Script.Base.Page.View;

namespace Script.Page.PageSample
{

    public interface ISampleView : IUIView<ISampleViewMessage>, ISampleViewMessage
    {
        //presenter to view
        void RenderUI();
    }

    public interface ISampleViewMessage
    {
        //view to presenter
        void OnClickOpenShop();
    }

    public class PageSampleParam : PageParam
    {

    }

    public class PageSampleResult : PageResult
    {

    }
}
