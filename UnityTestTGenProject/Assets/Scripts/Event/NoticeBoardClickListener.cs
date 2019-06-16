using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBoardClickListener : MonoBehaviour
{
    public float cameraZDistance;
    private static GameObject cloneObject;
    private void OnMouseDown()
    {
        if (cloneObject == null && GameController.CurrentPlayerState is PlayerState.Menu)
        {
            SpawnClone();
            MoveToCamera();
        }
    }

    private void MoveToCamera()
    {
        LeanTween.move(cloneObject, Camera.main.transform.position + Camera.main.transform.forward * cameraZDistance, 0.2f).setEaseInOutQuad();
        LeanTween.rotate(cloneObject, Camera.main.transform.rotation.eulerAngles, 0.3f);
    }

    private void SpawnClone()
    {
        cloneObject = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
        var boardClickListener = cloneObject.GetComponent<NoticeBoardClickListener>();
        Destroy(boardClickListener);
        var clickListener = cloneObject.AddComponent<ClickListener>();
        clickListener.onClickEvent += () => Destroy(cloneObject);
    }

    public static void DestroyClone()
    {
        if (cloneObject != null)
            Destroy(cloneObject);
    }

}
