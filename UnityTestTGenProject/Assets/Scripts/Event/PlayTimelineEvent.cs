using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimelineEvent : BaseGameEvent
{
    [SerializeField] private PlayableDirector targetDirector;
    [SerializeField] private Transform positionPointer;
    public override void TriggerEvent(GameObject eventTarget)
    {
        MoveTargetToPositionPointer(eventTarget);
        SetAnimationTrigger(eventTarget);
    }

    protected void SetAnimationTrigger(GameObject eventTarget)
    {
        targetDirector.Play();
    }

    protected void MoveTargetToPositionPointer(GameObject eventTarget)
    {
        if (positionPointer != null && eventTarget != null)
        {
            LeanTween.move(eventTarget, positionPointer.position, 0.3f);
            LeanTween.rotate(eventTarget, positionPointer.rotation.eulerAngles, 0.3f);
        }
    }

}
