using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickListener : MonoBehaviour
{
    public Action onClickEvent;
    private void OnMouseDown()
    {
        onClickEvent?.Invoke();
    }

}
