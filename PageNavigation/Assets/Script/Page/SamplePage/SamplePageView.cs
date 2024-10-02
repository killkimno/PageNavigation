﻿using Assets.Script.Base.Page;
using UnityEngine;

namespace Assets.Script.Page.SamplePage
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
    }
}
