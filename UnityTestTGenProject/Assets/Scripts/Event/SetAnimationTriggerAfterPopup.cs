using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTriggerAfterPopup : SetAnimationTriggerEvent
{
    private GameObject eventTarget;
    public override void TriggerEvent(GameObject eventTarget)
    {
        this.eventTarget = eventTarget;
        PopUpHandler.ShowPopup("Do you want to sit ?", PlayAnimation, null);
    }

    private void PlayAnimation()
    {
        SetAnimationTrigger(eventTarget);
        MoveTargetToPositionPointer(eventTarget);
    }
}
