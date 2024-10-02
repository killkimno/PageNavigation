using Assets.Script.Base.Page;
using Cysharp.Threading.Tasks;

namespace Assets.Script.Page.SamplePage
{
    [PrefabPath("Prefab/PageSample")]
    public class SamplePagePresenter : BasePresenter, ISampleViewMessage
    {
        public SamplePagePresenter(IUIView view) : base(view)
        {
            UnityEngine.Debug.Log("BasePresenter");
        }

        public override async UniTask OnBeforeOpenAsync()
        {
            await base.OnBeforeOpenAsync();
        }

        public override UniTask OnAfterOpenAsync()
        {
            return base.OnAfterOpenAsync();
        }

        public override async UniTask OnAfterCloseAsync()
        {
            await base.OnAfterCloseAsync();
        }

        public void OnClickTest()
        {
            throw new System.NotImplementedException();
        }
    }
}
