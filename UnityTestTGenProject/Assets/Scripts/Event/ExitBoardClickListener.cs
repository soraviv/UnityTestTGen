using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoardClickListener : MonoBehaviour
{
    public BaseGameEvent[] eventsToTrigger = new BaseGameEvent[0];
    private void OnMouseDown()
    {
        NoticeBoardClickListener.DestroyClone();
        foreach (var eventToTrigger in eventsToTrigger)
            eventToTrigger.TriggerEvent(null);
    }
}
