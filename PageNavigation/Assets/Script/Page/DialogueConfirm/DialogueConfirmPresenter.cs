using System;
using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using Script.Base.Page;
using Script.Base.Page.Presenter;

namespace Script.Page.DialogueConfirm
{
    [PrefabPath("Prefab/DialogueConfirm")]
    [PageLayer(PageLayerType.Dialogue)]
    [PageTransparent(false)]
    public class DialogueConfirmPresenter : BasePresenter, IDialogueConfirmViewMessage
    {
        private readonly IDialogueConfirmView _view;
        private DialogueConfirmParam _data;

        public DialogueConfirmPresenter(PageNavigator pageNavigator, IDialogueConfirmView view) : base(pageNavigator,
            view)
        {
            _view = view;
            view.SetViewMessage(this);
        }

        public override void InitData(PageParam param)
        {
            if (param is DialogueConfirmParam data)
            {
                _data = data;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public override async UniTask OnBeforeOpenAsync()
        {
            _view.RenderMessage(_data.Message);
            if (_data.OneButtonType)
            {
                _view.RenderOneButtonType();
            }
            else
            {
                _view.RenderTwoButtonType();
            }

            await base.OnBeforeOpenAsync();
        }

        public void OnClickOk()
        {
            _pageNavigator.SetResult(new DialogueConfirmResult(true));
            DoTryClose();
        }

        public void OnClickCancel()
        {
            _pageNavigator.SetResult(new DialogueConfirmResult(false));
            DoTryClose();
        }
    }
}