using Assets.Script.Base.Page;
using Assets.Script.Page;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Script.Base.Navigator
{
    public class NavigationTag
    {

    }

    public class PageNavigator 
    {
        private readonly LifetimeScope _lifetimeScope;
        private readonly PageResourceMapper _resourceMapper;
        private readonly Transform _disableRoot;
        private List<BasePresenter> _pageList = new List<BasePresenter>();
        public PageNavigator(LifetimeScope lifetimeScope, PageResourceMapper pageResourceMapper, Transform disableRoot)
        {         
            _lifetimeScope = lifetimeScope;
            _resourceMapper = pageResourceMapper;
            _disableRoot = disableRoot;
        }

        public async UniTask<IUILifetime> OpenAsync(PageType pageType)
        {

            var type = _resourceMapper.GetPageType(pageType);
            var path = type.GetCustomAttribute<PrefabPathAttribute>();

            //TODO : 리소스 로드 매니져가 필요하다 하지만 여기선 안 쓴다
            var resource = await Resources.LoadAsync<GameObject>(path.Path);

            var instance = GameObject.Instantiate(resource, _disableRoot) as GameObject;
            var lifetime = ResolvePresent<IUILifetime>(instance);

            await lifetime.OnBeforeOpenAsync();

            await lifetime.OnOpenAsync();

            await lifetime.OnAfterOpenAsync();

            return null;
        }

        private IUILifetime ResolvePresent<TBase>(GameObject obj) where TBase : IUILifetime
        {
            var childScope = obj.GetComponent<LifetimeScope>();
            childScope = _lifetimeScope.CreateChildFromPrefab(childScope);
            obj.SetActive(true);
            var result = childScope.Container.Resolve< TBase>();

            return result;
        }
    }
}
