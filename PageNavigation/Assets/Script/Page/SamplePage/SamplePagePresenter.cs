using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using Script.Base.Page;
using Script.Base.Page.Presenter;
using UnityEngine;

namespace Script.Page.SamplePage
{
    [PrefabPath("Prefab/PageSample")]
    public class SamplePagePresenter : BasePresenter, ISampleViewMessage
    {
        public SamplePagePresenter(ISampleView view, PageNavigator pageNavigator) : base(pageNavigator, view)
        {
            view.SetViewMessage(this);
            UnityEngine.Debug.Log("BasePresenter");
        }

        public override async UniTask OnBeforeOpenAsync()
        {
            UnityEngine.Debug.Log("before");
            await base.OnBeforeOpenAsync();
        }

        public override UniTask OnAfterOpenAsync()
        {
            UnityEngine.Debug.Log("after");
            return base.OnAfterOpenAsync();
        }

        public override async UniTask OnAfterCloseAsync()
        {
            await base.OnAfterCloseAsync();
        }

        public void OnClickOpenShop() => UniTask.Void(async () =>
        {
            var tag = await _pageNavigator.OpenAsync(PageType.Shop);

            await tag.AwaitAsync();

            Debug.Log($"complete");
        });
    }
}
