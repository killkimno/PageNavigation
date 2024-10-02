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
        //view�� ����ϳ� �������̽��� ����Ѵ�
        builder.RegisterComponent<SamplePageView>(_view).AsImplementedInterfaces();
    }
}
