﻿using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page
{
    public interface IUIView
    {
        GameObject GetGameObject { get; }
        void EnableView(bool enable);
        UniTask OpenAsync();
    }

    public interface IUIView<TMessage> : IUIView
    {
        //p <-->v 간 통신
        void SetViewMessage(TMessage message);
    }
}
