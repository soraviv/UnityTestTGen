using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupEvent : BaseGameEvent
{
    public string Message;
    public BaseGameEvent[] eventsToTrigger;
    private GameObject eventTarget;
    public override void TriggerEvent(GameObject eventTarget)
    {
        this.eventTarget = eventTarget;
        PopUpHandler.ShowPopup(Message, TriggerOtherEvent, null);
    }

    private void TriggerOtherEvent()
    {
        foreach (var eventToTrigger in eventsToTrigger)
            eventToTrigger?.TriggerEvent(this.eventTarget);
    }
}
