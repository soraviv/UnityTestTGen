using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IInteractableCharacter
{
    [SerializeField] private string charName;
    public string Name => charName;

    private Collider collider;
    private InteractionBubble interactionBubble;

    void Awake()
    {
        collider = GetComponent<Collider>();
        interactionBubble = GetComponentInChildren<InteractionBubble>();
    }
    private void Start()
    {
        interactionBubble.Hide();
    }
    
    public float GetHeight()
    {
        return collider.bounds.max.y - collider.bounds.min.y;
    }


    public void OnSelected()
    {
        interactionBubble.Show();
        interactionBubble.OnSelected();
    }

    public void OnDeselected()
    {
        interactionBubble.Hide();
    }
}
