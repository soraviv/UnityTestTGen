using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableEnvironment : MonoBehaviour, IInteractableCharacter
{
    public string Name { get; }

    private Collider collider;
    private InteractionBubble interactionBubble;

    void Awake()
    {
        collider = GetComponentInChildren<Collider>();
        interactionBubble = GetComponentInChildren<InteractionBubble>();
    }

    void Update()
    {

    }

    public float GetHeight()
    {
        return collider.bounds.max.y - collider.bounds.min.y;
    }

    public void OnSelected()
    {
        interactionBubble.OnSelected();
    }

    public void OnDeselected()
    {
        interactionBubble.ResetSelection();
    }
}
