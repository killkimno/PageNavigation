using Cysharp.Threading.Tasks;

namespace Script.Base.Page
{
    public interface IUILifetime
    {
        UniTask OnBeforeOpenAsync();
        UniTask OnOpenAsync();
        UniTask OnAfterOpenAsync();
        UniTask OnBeforeCloseAsync();
        UniTask OnAfterCloseAsync();
    }
}
