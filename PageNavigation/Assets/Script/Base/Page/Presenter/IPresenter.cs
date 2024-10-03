using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page
{
    public interface IPresenter : IUILifetime
    {
        void EnableView(bool enable);
        void SetRoot(Transform transform);
        UniTask<bool> ProceedBeforeCloseAsync();
    }
}
