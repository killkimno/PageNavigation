using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page
{
    public class ViewBase : MonoBehaviour, IUIView
    {
        public GameObject GetGameObject => gameObject;

        public void EnableView(bool enable) => gameObject.SetActive(enable);

        public async UniTask OpenAsync()
        {
            await UniTask.CompletedTask;
        }

    }
}
