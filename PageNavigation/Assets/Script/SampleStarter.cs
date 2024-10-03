using Cysharp.Threading.Tasks;
using Script.Base.Navigator;
using Script.Page;
using VContainer.Unity;

namespace Script
{
    public class SampleStarter : IInitializable
    {
        private readonly PageNavigator _pageNavigator;

        public SampleStarter(PageNavigator pageNavigator, PageResourceMapper pageResourceMapper)
        {
            _pageNavigator = pageNavigator;
        }

        public void Initialize()
        {
            _pageNavigator.OpenAsync(PageType.Sample).Forget();
        }
    }
}
