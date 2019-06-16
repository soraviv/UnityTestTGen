using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTriggerEvent : BaseGameEvent
{
    [SerializeField] private string triggerName;
    [SerializeField] private Transform positionPointer;
    public override void TriggerEvent(GameObject eventTarget)
    {
        MoveTargetToPositionPointer(eventTarget);
        SetAnimationTrigger(eventTarget);
    }

    protected void SetAnimationTrigger(GameObject eventTarget)
    {
        eventTarget.GetComponent<Animator>().SetTrigger(triggerName);
    }

    protected void MoveTargetToPositionPointer(GameObject eventTarget)
    {

        if (positionPointer != null)
        {
            eventTarget.transform.position = positionPointer.position;
            eventTarget.transform.rotation = positionPointer.rotation;
        }
    }

}
