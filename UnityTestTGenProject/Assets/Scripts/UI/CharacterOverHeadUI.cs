using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverHeadUI : MonoBehaviour
{

    private void Start()
    {
        var character = GetComponentInParent<ICharacter>();
        SetHeight(character);
    }
    public void SetHeight(ICharacter character)
    {
        transform.localPosition = Vector3.up * character.GetHeight();

    }

   
}
