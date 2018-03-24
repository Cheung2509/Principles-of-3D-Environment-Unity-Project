using UnityEngine;
using System.Collections;

public class CameraAngle : MonoBehaviour
{
    public Camera cameraBehind;
    public Camera cameraFront;
    public Camera cameraTop;

    void start()
    {
        cameraBehind.enabled = true;
        cameraFront.enabled = false;
        cameraTop.enabled = false;
    }

   public void lookForward()
    {
        cameraBehind.enabled = true;
        cameraFront.enabled = false;
        cameraTop.enabled = false;
    }

    public void lookBehind()
    {
        cameraBehind.enabled = false;
        cameraFront.enabled = true;
        cameraTop.enabled = false;
    }

    public void lookBelow()
    {
        cameraBehind.enabled = false;
        cameraFront.enabled = false;
        cameraTop.enabled = true;
    }
}
