using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTagUI : MonoBehaviour
{
    private TextMeshProUGUI textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
        var character = GetComponentInParent<ICharacter>();
        if (character != null)
            SetNameText(character.Name);
        else
            gameObject.SetActive(false);
    }

    public void SetNameText(string name)
    {
        textObject.text = name;
    }
}
