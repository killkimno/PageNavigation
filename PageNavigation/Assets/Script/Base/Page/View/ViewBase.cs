using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Base.Page.View
{
    public class ViewBase : MonoBehaviour, IUIView
    {
        public void SetRoot(Transform root)
        {
            gameObject.transform.SetParent(root);
            var rect = GetComponent<RectTransform>();

            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = Vector3.zero;
        }

        public void EnableView(bool enable) => gameObject.SetActive(enable);

        public async UniTask OpenAsync()
        {
            await UniTask.CompletedTask;
        }

        public async UniTask CloseAsync()
        {
            await UniTask.CompletedTask;
        }

        public virtual void DestroyView()
        {
            Destroy(gameObject);
        }
    }
}
