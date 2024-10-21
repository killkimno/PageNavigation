using Script.Base.Page.View;
using TMPro;
using UnityEngine;

namespace Script.Page.DialogueConfirm
{
    public class DialogueConfirmView : ViewBase, IDialogueConfirmView
    {
        [SerializeField] 
        private TMP_Text _lbMessage;

        [SerializeField] private GameObject _oneButtonType;
        [SerializeField] private GameObject _twoButtonType;

        private IDialogueConfirmViewMessage _message;
        
        public void SetViewMessage(IDialogueConfirmViewMessage message)
        {
            _message = message;
        }

        public void RenderMessage(string message)
        {
            _lbMessage.text = message;
        }

        public void RenderOneButtonType()
        {
            _oneButtonType.SetActive(true);
            _twoButtonType.SetActive(false);
        }

        public void RenderTwoButtonType()
        {
            _oneButtonType.SetActive(false);
            _twoButtonType.SetActive(true);
        }

        public void OnClickOk()
        {
            _message.OnClickOk();
        }

        public void OnClickCancel()
        {
            _message.OnClickCancel();
        }
    }
}