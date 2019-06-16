using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEventOnTrigger : MonoBehaviour
{
    public bool PlayerOnly = true;
    public BaseGameEvent[] eventsToTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerOnly && other.tag == "Player" || !PlayerOnly)
        {
            foreach (var eventToTrigger in eventsToTrigger)
                eventToTrigger?.TriggerEvent(other.gameObject);
        }
    }
}
