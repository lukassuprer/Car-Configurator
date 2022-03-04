using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public Transform Camera;
    public GameObject cameraRig;
    public List<Positions> positionsList = new List<Positions>();

    [System.Serializable]
    public class Positions
    {
        public Transform positionGameObject;
    }

    public void OnClickSpoiler(int index)
    {
        if (SpoilersManager.isOpened == true)
        {
            DisableCam(index);
        }
        else
        {
            EnableCam();
        }
    }

    public void OnClickSpoilerButton(int index)
    {
        DisableCam(index);
    }

    public void OnClickWheelsButton(int index)
    {
        DisableCam(index);
    }

    public void OnClickWheel(int index)
    {
        if (WheelsManager.isOpened == true)
        {
            DisableCam(index);
        }
        else
        {
            EnableCam();
        }
    }
    public void OnClickColor()
    {
        EnableCam();
    }

    private void DisableCam(int index)
    {
        Camera.position = positionsList[index].positionGameObject.position;
        Camera.rotation = positionsList[index].positionGameObject.rotation;

        cameraRig.GetComponent<CameraOrbit>().enabled = false;
    }

    public void EnableCam()
    {
        cameraRig.GetComponent<CameraOrbit>().enabled = true;
        Camera.position = cameraRig.transform.position;
        Camera.rotation = cameraRig.transform.rotation;
        cameraRig.GetComponent<CameraOrbit>().UnZoomCamera();
    }
}