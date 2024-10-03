using Cysharp.Threading.Tasks;
using Script.Page;

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
            await UniTask.WaitWhile(() => !Closed);
        }
    }
}
