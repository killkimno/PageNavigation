using Script.Base.Page;
using Script.Base.Page.Presenter;
using Script.Page;

namespace Script.Base.Navigator
{
    public class ContainedPresenter
    {
        public IPresenter Presenter { get; }
        public NavigationTag NavigationTag { get; }

        public PageType PageType => NavigationTag.PageType;

        public ContainedPresenter(IPresenter presenter, NavigationTag navigationTag)
        {
            Presenter = presenter;
            NavigationTag = navigationTag;
        }
    }
}
