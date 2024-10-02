using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Base.Page
{
    public interface IUIView
    {
        GameObject GetGameObject { get; }
        UniTask OpenAsync();        
    }

    public interface IUIView<TMessage> : IUIView
    {
        //p <-->v 간 통신
        void SetViewMessage(TMessage message);
    }

}
