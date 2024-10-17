using Script.Base.Page;
using Script.Base.Page.View;

namespace Script.Page.DialogueConfirm
{
    public interface IDialogueConfirmView : IUIView<IDialogueConfirmViewMessage>
    {
        void RenderMessage(string message);
        void RenderOneButtonType();
        void RenderTwoButtonType();
    }

    public interface IDialogueConfirmViewMessage
    {
        void OnClickOk();
        void OnClickCancel();
    }

    public class DialogueConfirmParam : PageParam
    {
        public string Message { get; }
        public bool OneButtonType { get; }

        public DialogueConfirmParam(string message, bool oneButtonType)
        {
            Message = message;
            OneButtonType = oneButtonType;
        }
    }

    public class DialogueConfirmResult : PageResult
    {
        public bool Confirm { get; }

        public DialogueConfirmResult(bool confirm)
        {
            Confirm = confirm;
        }
    }
}