using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using Script.Base.Page.View;
using UnityEngine;

namespace Script.Base.Page.Presenter
{
    public class BasePresenter : IPresenter
    {
        protected readonly PageNavigator _pageNavigator;
        protected IUIView _uIView;

        public BasePresenter(PageNavigator pageNavigator, IUIView view)
        {
            UnityEngine.Debug.Log("BasePresenter");
            _pageNavigator = pageNavigator;
            _uIView = view;
        }

        public virtual UniTask OnBeforeOpenAsync()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask OnOpenAsync()
        {
            await _uIView.OpenAsync();
        }

        public virtual UniTask OnAfterOpenAsync()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnBeforeCloseAsync()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask OnCloseAsync()
        {
            await _uIView.CloseAsync();
        }

        public virtual UniTask OnAfterCloseAsync()
        {
            return UniTask.CompletedTask;
        }

        public virtual void DestroyView() => _uIView.DestroyView();

        public void EnableView(bool enable) => _uIView.EnableView(enable);

        public void SetRoot(Transform transform) => _uIView.SetRoot(transform);

        /// <summary>
        /// 닫기 작업을 하기 전에 마무리 작업을 한다 -> ex : 변경 사항을 저장하겠습니까? 팝업
        /// return 값은 인터럽트 여부다 -> true -> 인터럽트 발생 -> 닫기 작업 취소 / false -> 닫으면 된다
        /// </summary>
        /// <returns></returns>
        public async virtual UniTask<bool> ProceedBeforeCloseAsync()
        {
            await UniTask.CompletedTask;
            return false;
        }

        protected void DoTryClose() => UniTask.Void(async () =>
        {
            if (await ProceedBeforeCloseAsync())
            {
                return;
            }

            _pageNavigator.CloseAsync().Forget();
        });
    }
}
