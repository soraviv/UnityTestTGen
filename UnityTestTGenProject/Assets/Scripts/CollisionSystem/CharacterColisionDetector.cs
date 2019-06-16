using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColisionDetector : MonoBehaviour
{
    private IInteractableCharacter closestCharacter;
    private List<IInteractableCharacter> allCharacterInRange = new List<IInteractableCharacter>();
    void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<IInteractableCharacter>();

        if (character != null)
        {
            allCharacterInRange.Add(character);
        }
    }
    void OnTriggerExit(Collider other)
    {
        var character = other.GetComponent<IInteractableCharacter>();
        if (character != null)
        {
            if (character == closestCharacter)
                character.OnDeselected();
            allCharacterInRange.Remove(character);
        }
    }

    void Update()
    {
        var character = GetClosestCharacter();
        if (closestCharacter != character)
        {
            if (closestCharacter != null)
                closestCharacter.OnDeselected();
            if (character != null)
                character.OnSelected();
            closestCharacter = character;
        }
    }

    private IInteractableCharacter GetClosestCharacter()
    {
        IInteractableCharacter closest = null;
        foreach (var character in allCharacterInRange)
        {
            if (closest == null)
                closest = character;
            var closestDistance = Vector3.Distance(transform.position, closest.transform.position);
            var characterDistance = Vector3.Distance(transform.position, character.transform.position);
            if (characterDistance < closestDistance)
                closest = character;
        }
        return closest;
    }
}