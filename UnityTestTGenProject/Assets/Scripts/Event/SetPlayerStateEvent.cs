using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerStateEvent : BaseGameEvent
{
    public PlayerState State;
    public override void TriggerEvent(GameObject eventTarget)
    {
        GameController.SetPlayerState(State);
    }
}
