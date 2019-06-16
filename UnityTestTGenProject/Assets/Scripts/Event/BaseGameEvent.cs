using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent : MonoBehaviour, IGameEvent
{
    public abstract void TriggerEvent(GameObject eventTarget);
}
