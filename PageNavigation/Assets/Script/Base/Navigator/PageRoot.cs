using UnityEngine;

namespace Script.Base.Navigator
{
    public class PageRoot : MonoBehaviour
    {
        [SerializeField]
        private Transform _pageRoot;

        public Transform Root => _pageRoot;
    }
}
