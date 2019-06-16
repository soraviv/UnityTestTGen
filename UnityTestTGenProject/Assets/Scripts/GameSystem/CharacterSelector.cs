using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] PlayerPrefabs = new GameObject[2];
    public PlayerCharacter BasePlayerObject;

    public Canvas CharacterSelectCanvas;
    public TMP_InputField playerNameInputField;

    public void SelectCharacter(int characterIndex)
    {

        if (BasePlayerObject == null)
            BasePlayerObject = FindObjectOfType<PlayerCharacter>();
        //var selectedCharacter = Instantiate(PlayerPrefabs[characterIndex]);
        //AssemblePlayerCharacter(selectedCharacter);
        BasePlayerObject.SetCharacterName(playerNameInputField.text);
        gameObject.SetActive(false);
        GameController.SetPlayerState(PlayerState.Walking);
    }

    private void AssemblePlayerCharacter(GameObject selectedCharacter)
    {
        var baseAnimator = BasePlayerObject.GetComponent<Animator>();
        var selectedCharacterAnimator = selectedCharacter.GetComponent<Animator>();
        baseAnimator.avatar = selectedCharacterAnimator.avatar;

        while (selectedCharacter.transform.childCount > 0)
        {
            var child = selectedCharacter.transform.GetChild(0);
            child.SetParent(BasePlayerObject.transform);
            child.localPosition = Vector3.zero;
            child.localRotation = Quaternion.identity;
        }
        baseAnimator.Rebind();
    }
}
