
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StopTimelineEvent : BaseGameEvent
{
    [SerializeField] private PlayableDirector targetDirector;
    public override void TriggerEvent(GameObject eventTarget)
    {
        targetDirector.Stop();
    }
}
