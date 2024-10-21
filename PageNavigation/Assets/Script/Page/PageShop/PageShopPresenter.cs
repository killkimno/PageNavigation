using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using Script.Base.Page;
using Script.Base.Page.Presenter;
using Script.Base.Page.View;
using Script.Page.DialogueConfirm;
using UnityEngine;

namespace Script.Page.PageShop
{
    [PrefabPath("Prefab/PageShop")]
    [PageLayer(0)]
    public class PageShopPresenter : BasePresenter, IPageShopViewMessage
    {
        private readonly IUIView _view;

        public PageShopPresenter(PageNavigator pageNavigator, IPageShopView view) : base(pageNavigator, view)
        {
            _view = view;
            view.SetViewMessage(this);
        }

        public void OnClickBack()
        {
            DoTryClose();
        }

        public void OnClickOpenDialogue() => UniTask.Void(async () =>
        {
            var tag = await _pageNavigator.OpenAsync(PageType.Dialogue, new DialogueConfirmParam("Test", true));

            await tag.AwaitAsync();

            if (tag.PageResult is DialogueConfirmResult result)
            {
                Debug.Log(result.Confirm);
            }
        });
    }
}