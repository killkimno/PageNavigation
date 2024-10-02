using Assets.Script.Page.SamplePage;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SamplePageLifetimeScope : LifetimeScope
{
    [SerializeField]
    private SamplePageView _view;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SamplePagePresenter>(Lifetime.Scoped);
        //view를 등록하나 인터페이스만 등록한다
        builder.RegisterComponent<SamplePageView>(_view).AsImplementedInterfaces();
    }
}
