using Cysharp.Threading.Tasks;

namespace Assets.Script.Base.Page
{
    public class BasePresenter : IUILifetime
    {
        private IUIView _uIView;
        public BasePresenter(IUIView view)
        {
            UnityEngine.Debug.Log("BasePresenter");
            _uIView = view;
        }

        /// <summary>
        /// UI 열기전 준비과정
        /// </summary>
        /// <returns></returns>
        public virtual UniTask OnBeforeOpenAsync()
        {
            return UniTask.CompletedTask;
        }

        /// <summary>
        /// UI를 여는 과정 - 주로 연출이다
        /// </summary>
        /// <returns></returns>
        public async UniTask OnOpenAsync()
        {
            await _uIView.OpenAsync();
        }

        /// <summary>
        /// UI를 연 후 후속과정
        /// </summary>
        /// <returns></returns>
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
       
    }
}

