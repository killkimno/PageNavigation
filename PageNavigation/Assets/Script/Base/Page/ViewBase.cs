using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Base.Page
{
    public class ViewBase : MonoBehaviour, IUIView
    {
        public GameObject GetGameObject => gameObject;

        public async UniTask OpenAsync()
        {
            await UniTask.CompletedTask;
        }
    }
}
