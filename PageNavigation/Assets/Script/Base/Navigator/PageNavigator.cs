using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using Script.Base.Navigator.MultipleOpener;
using Script.Base.Page;
using Script.Base.Page.Presenter;
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

        public async UniTask<NavigationTag> OpenAsync(PageType pageType, PageParam pageParam = null)
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

            presenter.InitData(pageParam);
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
                current.Presenter.DestroyView();

                _pageList.Remove(current);

                //이전걸 연다
                var previous = _pageList.Last();
                previous.Presenter.EnableView(true);
                await previous.Presenter.OnBeforeOpenAsync();
                await previous.Presenter.OnOpenAsync();
                previous.Presenter.OnAfterOpenAsync().Forget();
            }
        }

        private async UniTask CloseAllAsync()
        {
            //강제로 모두 닫는다 -> 닫는 연출을 안 한다
            for (int i = _pageList.Count - 1; i == 0; i--)
            {
                await _pageList[i].Presenter.OnAfterCloseAsync();
                _pageList[i].Presenter.DestroyView();
                _pageList[i].NavigationTag.SetClosed();
            }

            _pageList.Clear();
        }

        private async UniTask CloseAllAsync(PageType breakPointType)
        {
            while (_pageList.Count > 0)
            {
                var last = _pageList.Last();

                if (last.PageType == breakPointType)
                {
                    break;
                }

                await last.Presenter.OnAfterCloseAsync();
                last.Presenter.DestroyView();
                last.NavigationTag.SetClosed();

                _pageList.Remove(last);
            }
        }

        /// <summary>
        /// 페이지를 경로 방식으로 연다
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async UniTask<NavigationTag> OpenMultipleAsync(List<PageMultiOpenerModel> models)
        {
            if (models?.Count == 0)
            {
                throw new ArgumentException();
            }

            //1. 현재 열린 페이지와 모델로 온 페이지를 처음부터 비교한다
            //2. 모델이 다른 지점이 생긴다 -> 거기까지 모두 닫는다
            //3. 모델에 남은 페이지를 넣는다

            int sameIndex = -1;
            bool same = models.Count == _pageList.Count;
            for (int i = 0; i < models.Count && i < _pageList.Count; i++)
            {
                if (models[i].PageType != _pageList[i].PageType)
                {
                    same = false;
                    break;
                }

                sameIndex = i;
            }

            if (same)
            {
                //모두 같다 -> 현재 마지막을 리턴한다
                return _pageList.Last().NavigationTag;
            }

            if (sameIndex == -1)
            {
                await CloseAllAsync();
            }
            else
            {
                await CloseAllAsync(_pageList[sameIndex].PageType);
            }

            if (sameIndex > models.Count)
            {
                //기존 경로에 포함된채로 마무리 된거다 -> 마지막을 다시 열어줘야한다
                var last = _pageList.Last();
                await last.Presenter.OnBeforeOpenAsync();
                await last.Presenter.OnOpenAsync();
                await last.Presenter.OnAfterOpenAsync();
                return _pageList.Last().NavigationTag;
            }

            for (int i = sameIndex + 1; i < models.Count; i++)
            {
                await OpenAsync(models[i].PageType, models[i].PageParam);
            }

            return null;
        }

        /// <summary>
        /// 페이지를 닫았을 때 결과를 저장한다 - 마지막 네비게이션 테그에 저장한다
        /// </summary>
        /// <param name="pageResult"></param>
        public void SetResult(PageResult pageResult)
        {
            if (_pageList.Count == 0)
            {
                return;
            }

            var lastNavigationTag = _pageList.Last().NavigationTag;
            lastNavigationTag.SetResult(pageResult);
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
