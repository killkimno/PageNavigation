using Assets.Script.Base.Navigator;
using Assets.Script.Base.Page;
using Assets.Script.Page;
using Assets.Script.Page.SamplePage;
using Cysharp.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using VContainer.Unity;

namespace Assets.Script
{
    public class SampleStarter : IInitializable
    {
        private readonly PageNavigator _pageNavigator;

        public SampleStarter(PageNavigator pageNavigator)
        {
            _pageNavigator = pageNavigator;
        }

        public void Initialize()
        {
            _pageNavigator.OpenAsync(PageType.Sample).Forget();
        }
    }
}
