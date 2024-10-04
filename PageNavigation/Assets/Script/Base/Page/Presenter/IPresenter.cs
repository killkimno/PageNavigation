using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page.Presenter
{
    public interface IPresenter : IUILifetime
    {
        void InitData(PageParam param);
        void EnableView(bool enable);
        void SetRoot(Transform transform);
        UniTask<bool> ProceedBeforeCloseAsync();
    }
}
