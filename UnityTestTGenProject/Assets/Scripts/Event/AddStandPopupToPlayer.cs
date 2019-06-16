using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStandPopupToPlayer : BaseGameEvent
{
    public string Message;
    private GameObject eventTarget;
    public override void TriggerEvent(GameObject eventTarget)
    {
        this.eventTarget = eventTarget;
        var clickListener = eventTarget.GetComponent<ClickListener>();
        clickListener.onClickEvent += TriggerPopupEvent;
    }

    private void TriggerPopupEvent()
    {
        PopUpHandler.ShowPopup(Message, Confirm, null);
    }

    private void Confirm()
    {
        eventTarget.GetComponent<Animator>().SetTrigger("Walk");
        GameController.SetPlayerState(PlayerState.Walking);
        var clickListener = eventTarget.GetComponent<ClickListener>();
        clickListener.onClickEvent -= TriggerPopupEvent;
    }
}
