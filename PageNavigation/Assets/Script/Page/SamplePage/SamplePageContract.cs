using Script.Base.Page;

namespace Script.Page.SamplePage
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

    public class SamplePageParam : PageParam
    {

    }

    public class SamplePageResult : PageResult
    {

    }
}
