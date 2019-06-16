using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopUpHandler : MonoBehaviour
{
    private static PopUpHandler _instance;
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TMPro.TextMeshProUGUI popupMessage;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;

    private PlayerState previousState;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        ClosePopup();
    }

    public static void ShowPopup(string popupMessage, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        _instance.SetUpPopUp(popupMessage, confirmEvent, cancelEvent);
        _instance.ShowPopup();
    }

    private void PlayPopupAnimation()
    {
        if (popupPanel.activeInHierarchy)
            return;
        popupPanel.SetActive(true);
        var originalScale = popupPanel.transform.localScale;
        popupPanel.transform.localScale = Vector3.zero;
        LeanTween.scale(popupPanel, originalScale, 0.2f).setEaseInBounce();
    }

    private void SetUpPopUp(string message, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        this.popupMessage.text = message;

        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(ClosePopup);
        if (confirmEvent != null)
            confirmButton.onClick.AddListener(confirmEvent);

        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(ClosePopup);
        if (cancelEvent != null)
            cancelButton.onClick.AddListener(cancelEvent);

    }

    private void ShowPopup()
    {
        PlayPopupAnimation();
        previousState = GameController.CurrentPlayerState;
        GameController.SetPlayerState(PlayerState.Menu);
    }

    private void ClosePopup()
    {
        GameController.SetPlayerState(previousState);
        popupPanel.SetActive(false);
    }

}
