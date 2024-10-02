using Assets.Script.Base.Page;
using Assets.Script.Page;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
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
        private List<BasePresenter> _pageList = new List<BasePresenter>();
        public PageNavigator(LifetimeScope lifetimeScope, PageResourceMapper pageResourceMapper)
        {
            _lifetimeScope = lifetimeScope;
            _resourceMapper = pageResourceMapper;
        }

        public async UniTask<NavigationTag> OpenAsync(PageType pageType)
        {

            var type = _resourceMapper.GetPageType(pageType);
            var path = type.GetCustomAttribute<PrefabPathAttribute>();

            //TODO : 리소스 로드 매니져가 필요하다 하지만 여기선 안 쓴다

            GameObject instance = GameObject.Instantiate(Resources.Load(path.Path, typeof(GameObject))) as GameObject;

            await UniTask.CompletedTask;

            

            return null;
        }
    }
}
