
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SetActiveGameObjectEvent : BaseGameEvent
{
    public bool targetObjectState = false;
    public GameObject[] gameObjectsToSetActive;
    public override void TriggerEvent(GameObject eventTarget)
    {
        foreach (var go in gameObjectsToSetActive)
            go.SetActive(targetObjectState);
    }
}
