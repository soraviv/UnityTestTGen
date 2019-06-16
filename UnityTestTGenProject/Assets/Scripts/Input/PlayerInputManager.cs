using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerInputManager : MonoBehaviour
{
    public static System.Action OnInputMethodChange;
    public static IPlayerInputMethod PlayerInputMethod { get; private set; }
    [SerializeField] private PlayerInputMethodBase defaultInputMethod;

    private void Awake()
    {
        PlayerInputMethod = defaultInputMethod;
        PlayerInputMethod.VirtualCam.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !(PlayerInputMethod is CharacterMoveWithArrow))
            SwitchInputMethod(GetComponent<CharacterMoveWithArrow>());
        if (Input.GetKeyDown(KeyCode.F2) && !(PlayerInputMethod is CharacterMoveWithPointClick))
            SwitchInputMethod(GetComponent<CharacterMoveWithPointClick>());
        if (PlayerInputMethod == null)
            SwitchInputMethod(GetComponent<IPlayerInputMethod>());

        PlayerInputMethod.UpdatePlayerMovement();
    }

    private void SwitchInputMethod(IPlayerInputMethod newInputMethod)
    {
        PlayerInputMethod.VirtualCam.gameObject.SetActive(false);
        newInputMethod.VirtualCam.gameObject.SetActive(true);
        PlayerInputMethod = newInputMethod;
        OnInputMethodChange?.Invoke();
    }
}
