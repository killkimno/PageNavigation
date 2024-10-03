using Cysharp.Threading.Tasks;

namespace Script.Base.Page
{
    public class BasePresenter : IPresenter
    {
        private IUIView _uIView;

        public BasePresenter(IUIView view)
        {
            UnityEngine.Debug.Log("BasePresenter");
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

        public virtual UniTask OnAfterCloseAsync()
        {
            return UniTask.CompletedTask;
        }

        public void EnableView(bool enable) => _uIView.EnableView(enable);
    }
}
