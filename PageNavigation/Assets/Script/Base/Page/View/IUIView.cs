using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page.View
{
    public interface IUIView
    {
        void SetRoot(Transform root);
        void EnableView(bool enable);
        UniTask OpenAsync();
        UniTask CloseAsync();
        void DestroyView();
    }

    public interface IUIView<TMessage> : IUIView
    {
        //p <-->v 간 통신
        void SetViewMessage(TMessage message);
    }
}
