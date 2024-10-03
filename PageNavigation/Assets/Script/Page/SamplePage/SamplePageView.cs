using Script.Base.Page;
using Script.Base.Page.View;
using UnityEngine;

namespace Script.Page.SamplePage
{
    public class SamplePageView : ViewBase, ISampleView
    {
        [SerializeField]
        private GameObject go;

        private ISampleViewMessage _message;
        public void RenderUI()
        {
            throw new System.NotImplementedException();
        }

        public void SetViewMessage(ISampleViewMessage message)
        {
            _message = message;
        }

        public void OnClickOpenShop() => _message.OnClickOpenShop();
    }
}
