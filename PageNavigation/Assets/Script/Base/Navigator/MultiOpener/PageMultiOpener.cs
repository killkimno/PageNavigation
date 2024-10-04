using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Script.Base.Page;
using Script.Page;

namespace Script.Base.Navigator.MultiOpener
{
    public class PageMultiOpenerModel
    {
        public PageType PageType { get; }
        public PageParam PageParam { get; }

        public PageMultiOpenerModel(PageType pageType, PageParam pageParam = null)
        {
            PageType = pageType;
            PageParam = pageParam;
        }
    }

    public class PageMultipleOpener
    {
        private readonly PageNavigator _pageNavigator;
        private readonly List<PageMultiOpenerModel> _models;

        public PageMultipleOpener(PageNavigator pageNavigator, List<PageMultiOpenerModel> models)
        {
            _pageNavigator = pageNavigator;
            _models = models;
        }

        private async UniTask<NavigationTag> OpenMultipleAsync()
        {
            var tag = await _pageNavigator.OpenMultipleAsync(_models);
            return tag;
        }
    }
}
