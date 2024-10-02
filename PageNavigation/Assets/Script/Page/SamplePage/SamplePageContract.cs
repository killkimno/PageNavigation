using Assets.Script.Base.Page;

namespace Assets.Script.Page.SamplePage
{

    public interface ISampleView : IUIView<ISampleViewMessage>
    {
        //presenter to view
        void RenderUI();
    }

    public interface ISampleViewMessage
    {
        //view to presenter
        void OnClickTest();
    }

    public class SamplePageParam : PageParam
    {

    }

    public class SamplePageResult : PageResult
    {

    }
}
