using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using UnityEngine;

namespace Script.Base.Page
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

        public void EnableView(bool enable) => _uIView.EnableView(enable);

        public void SetRoot(Transform transform)
        {
            var obj = _uIView.GetGameObject();
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector3.zero;

        }

        public UniTask<bool> ProceedBeforeCloseAsync() => throw new System.NotImplementedException();
    }
}
