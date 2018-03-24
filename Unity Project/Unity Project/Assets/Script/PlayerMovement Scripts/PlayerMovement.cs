using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;
    public float upDownRange = 60.0f;

    //Private Variables
    private GameObject camera;
    private CharacterController cc;
	// Use this for initialization
	void Start ()
    {
        cc = GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Caching input
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float rotateLeftRight = Input.GetAxis("LookLeftRight") * mouseSensitivity;
        float rotateUpDown = Input.GetAxis("LookUpDown") * mouseSensitivity;

        MovementManagement(moveVertical, moveHorizontal, rotateLeftRight, rotateUpDown);
	}

    //Function to manage the movement of the player
    void MovementManagement(float vertical, float horizontal, float rotateLeftRight, float rotateUpDown)
    {
        //Rotations
        transform.Rotate(0, rotateLeftRight, 0);
        camera.transform.Rotate(-rotateUpDown, 0, 0);
        
        //Movement
        Vector3 speed = new Vector3(horizontal, 0, vertical);
        speed = transform.rotation * speed;
        cc.SimpleMove(speed);
    }
}
