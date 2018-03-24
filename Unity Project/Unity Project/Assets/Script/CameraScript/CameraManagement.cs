using UnityEngine;
using System.Collections;

public class CameraManagement : MonoBehaviour
{
    private CameraAngle cameraAngle;
	// Use this for initialization
	void Start ()
    {
        cameraAngle = GetComponent<CameraAngle>();
	}
	
    void Update()
    {
        bool lookBehind = Input.GetButton("Look Behind");
        bool lookBelow = Input.GetButton("Look Below");

        changeCameraAngle(lookBehind, lookBelow);
    }

    void changeCameraAngle(bool lookBehind, bool lookBelow)
    {
        if(lookBelow)
        {
            cameraAngle.lookBelow();
        }
        else if (lookBehind)
        {
            cameraAngle.lookBehind();
        }
        else
        {
            cameraAngle.lookForward();
        }
    }
}
