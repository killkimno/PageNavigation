using Script.Base.Page.Presenter;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Script.Page.DialogueConfirm
{
    public class DialogueConfirmLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private DialogueConfirmView _view;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<DialogueConfirmPresenter>(Lifetime.Scoped).As<IPresenter>();
            builder.RegisterComponent<DialogueConfirmView>(_view).AsImplementedInterfaces();
        }
    }
}