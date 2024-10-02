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
        /// UI ������ �غ����
        /// </summary>
        /// <returns></returns>
        public virtual UniTask OnBeforeOpenAsync()
        {
            return UniTask.CompletedTask;
        }

        /// <summary>
        /// UI�� ���� ���� - �ַ� �����̴�
        /// </summary>
        /// <returns></returns>
        public async UniTask OnOpenAsync()
        {
            await _uIView.OpenAsync();
        }

        /// <summary>
        /// UI�� �� �� �ļӰ���
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

