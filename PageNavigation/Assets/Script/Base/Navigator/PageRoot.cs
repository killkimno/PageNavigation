using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Base.Navigator
{
    public class PageRoot : MonoBehaviour
    {
        [SerializeField]
        private Transform _pageRoot;

        [SerializeField]
        private List<Transform> _layers;

        public Transform Root => _pageRoot;

        public Transform GetLayer(int index)
        {
            if (_layers.Count <= index)
            {
                throw new IndexOutOfRangeException();
            }

            return _layers[index];
        }
    }
}
