using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Script.Base.Page;
using Script.Page;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Base.Navigator
{
    public class NavigationTag
    {
        //마지막으로 열린 ui의 테그 -> tag를 사용하고 있는데 또다시 새로운 ui가 열리면 문제가 발생한다 -> 해당 사항은 고려를 안 한다
        public PageType PageType { get; }
        public bool Closed { get; private set; } = false;

        public NavigationTag(PageType pageType)
        {
            PageType = pageType;
        }

        public void SetClosed()
        {
            Closed = true;
        }

        public async UniTask AwaitAsync()
        {
            await UniTask.WaitWhile(() => Closed);
        }
    }

    public class PageNavigator
    {
        private readonly LifetimeScope _lifetimeScope;
        private readonly PageResourceMapper _resourceMapper;
        private readonly Transform _disableRoot;
        private List<BasePresenter> _pageList = new List<BasePresenter>();

        private NavigationTag _lastNavigationTag;

        public PageNavigator(LifetimeScope lifetimeScope, PageResourceMapper pageResourceMapper, Transform disableRoot)
        {
            _lifetimeScope = lifetimeScope;
            _resourceMapper = pageResourceMapper;
            _disableRoot = disableRoot;
        }


        public async UniTask<NavigationTag> OpenAsync(PageType pageType)
        {
            var type = _resourceMapper.GetPageType(pageType);
            var pathAttribute = type.GetCustomAttribute<PrefabPathAttribute>();

            //TODO : 리소스 로드 매니져가 필요하다 하지만 여기선 안 쓴다
            var resource = await Resources.LoadAsync<GameObject>(pathAttribute.Path);

            var instance = GameObject.Instantiate(resource, _disableRoot) as GameObject;
            var lifetime = ResolvePresent<IUILifetime>(instance);

            //과정
            //1.1 이전걸 닫는 방시인가?
            //-이전게 있는가? -> 있다 onCloseAsync까지 처리한다 -> LastTag.Closed 한다
            //-이전게 없난가 -> 넘어간다
            //pageList에서 가장 마지막을 제거한다
            //1.2 이전게 없는가 -> 넘어간다
            //2 push 작업

            bool hidePrevious = true;


            await lifetime.OnBeforeOpenAsync();


            if (hidePrevious && _pageList.Count > 0)
            {
                var previous = _pageList[_pageList.Count - 1];

                //닫는 연출은 이때 안 한다
                previous.EnableView(false);
            }

            await lifetime.OnOpenAsync();

            await lifetime.OnAfterOpenAsync();


            return null;
        }

        private IUILifetime ResolvePresent<TBase>(GameObject obj) where TBase : IUILifetime
        {
            var childScope = obj.GetComponent<LifetimeScope>();
            childScope = _lifetimeScope.CreateChildFromPrefab(childScope);
            obj.SetActive(true);
            var result = childScope.Container.Resolve<TBase>();

            return result;
        }
    }
}
