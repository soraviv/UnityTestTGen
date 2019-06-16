using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InteractionBubble : MonoBehaviour
{
    // Start is called before the first frame update
    private ICharacter trackingCharacter;
    public float imageYSize = 0.5f;
    [SerializeField] private Button bubbleButton;
    private Animator anim;
    void Awake()
    {
        bubbleButton = GetComponent<Button>();
        anim = GetComponent<Animator>();
    }

    public void OnSelected()
    {
        anim.SetTrigger("Highlighted");
    }

    public void ResetSelection()
    {
        anim.SetTrigger("Normal");
    }

    public void Show()
    {
        bubbleButton.image.enabled = true;
    }

    public void Hide()
    {
        bubbleButton.image.enabled = false;
    }

    private void OnClosestCharacterChange(ICharacter character)
    {
        if (character == null)
        {
            bubbleButton.image.enabled = false;
            trackingCharacter = null;
        }
        else if (character is NPC)
        {
            bubbleButton.image.enabled = true;
            trackingCharacter = character;
        }

    }
}
