using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StopMouseInputOnPopup : MonoBehaviour
{
    CinemachineVirtualCameraBase virtualCam;

    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCameraBase>();
        GameController._onStateChange += OnGameStateChange;
    }

    private void OnGameStateChange(PlayerState newState)
    {
        virtualCam.enabled = newState is PlayerState.Walking;
    }
}
