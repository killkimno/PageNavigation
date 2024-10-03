using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Script.Base.Page;
using Script.Page;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Base.Navigator
{
    public class PageNavigator
    {
        private readonly LifetimeScope _lifetimeScope;
        private readonly PageResourceMapper _resourceMapper;
        private readonly Transform _disableRoot;
        private readonly PageRoot _pageRoot;
        private List<ContainedPresenter> _pageList = new List<ContainedPresenter>();

        private List<NavigationTag> _navigationTags = new List<NavigationTag>();

        public PageNavigator(LifetimeScope lifetimeScope, PageResourceMapper pageResourceMapper, Transform disableRoot, PageRoot pageRoot)
        {
            _lifetimeScope = lifetimeScope;
            _resourceMapper = pageResourceMapper;
            _disableRoot = disableRoot;
            _pageRoot = pageRoot;
        }


        public async UniTask<NavigationTag> OpenAsync(PageType pageType)
        {
            var type = _resourceMapper.GetPageType(pageType);
            var pathAttribute = type.GetCustomAttribute<PrefabPathAttribute>();

            //TODO : 리소스 로드 매니져가 필요하다 하지만 여기선 안 쓴다
            var resource = await Resources.LoadAsync<GameObject>(pathAttribute.Path);

            var instance = GameObject.Instantiate(resource, _disableRoot) as GameObject;
            var presenter = ResolvePresent<IPresenter>(instance);

            //과정
            //1.1 이전걸 닫는 방시인가?
            //-이전게 있는가? -> 있다 onCloseAsync까지 처리한다 -> LastTag.Closed 한다
            //-이전게 없난가 -> 넘어간다
            //pageList에서 가장 마지막을 제거한다
            //1.2 이전게 없는가 -> 넘어간다
            //2 push 작업

            bool hidePrevious = true;


            await presenter.OnBeforeOpenAsync();
            presenter.EnableView(true);
            presenter.SetRoot(_pageRoot.transform);

            if (hidePrevious && _pageList.Count > 0)
            {
                var previous = _pageList[_pageList.Count - 1];

                //닫는 연출은 이때 안 한다
                previous.Presenter.EnableView(false);
            }

            var navigationTag = new NavigationTag(pageType);
            _pageList.Add(new ContainedPresenter(presenter, navigationTag));
            await presenter.OnOpenAsync();
            presenter.OnAfterOpenAsync().Forget();

            return navigationTag;
        }

        public async UniTask CloseAsync()
        {
            if (_pageList.Count > 0)
            {
                //현재걸 닫는다
                var current = _pageList.Last();

                await current.Presenter.OnBeforeCloseAsync();
                await current.Presenter.OnCloseAsync();
                current.Presenter.OnAfterCloseAsync().Forget();
                current.NavigationTag.SetClosed();
                _pageList.Remove(current);

                //이전걸 연다
                var previous = _pageList.Last();
                await previous.Presenter.OnBeforeOpenAsync();
                await previous.Presenter.OnOpenAsync();
                previous.Presenter.OnAfterOpenAsync().Forget();
            }
        }

        private IPresenter ResolvePresent<TPresenter>(GameObject obj) where TPresenter : IPresenter
        {
            var childScope = obj.GetComponent<LifetimeScope>();
            childScope = _lifetimeScope.CreateChildFromPrefab(childScope);
            obj.SetActive(true);
            var result = childScope.Container.Resolve<TPresenter>();

            return result;
        }
    }
}
