using Cysharp.Threading.Tasks;

namespace Script.Base.Page.Presenter
{
    public interface IUILifetime
    {
        UniTask OnBeforeOpenAsync();
        UniTask OnOpenAsync();
        UniTask OnAfterOpenAsync();
        UniTask OnBeforeCloseAsync();
        UniTask OnCloseAsync();
        UniTask OnAfterCloseAsync();
    }
}
