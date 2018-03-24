using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{
    //Public Variables
    public bool doorOpenable;   //To see if the door is openable
    public bool doorSwitch;   // boolean variable to determin to open the door
    public bool doorOpenedClosed = false;
    public float rotationSpeed = 12f;   // the speed which the door opens
    public float targetRotation = 90f;  // Amount of degrees the door will rotate
    /// </summary>
    //Private Variables
    private GameObject switchObject;    //the switch for the doo
    private SwitchScript switchScript;  //referencing the switch script
    private GameObject gameControllerObject;    //Gameobject to reference the game controller
    private GameController gameController;  //referencing script from the game controller
    private float circumference; //circumference of the door
    private float rotationAmount; //amount of rotation per second
    private float moveAmount;   //the amount of movement per degree of rotation
    private bool doorOpeningClosing = false; //when the door is opening
    private float doorRotated = 0f; //amount of degree the door has rotated
	// Use this for initialization
	void Start ()
    {
        //Getting components from the switch
        switchObject = GameObject.FindGameObjectWithTag(name + "Switch");
        switchScript = switchObject.GetComponent<SwitchScript>();

        //Getting componets from the game controller
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();


        //Calculating the movement variables of the door
        circumference = 2 * Mathf.PI * 1;
        rotationAmount = rotationSpeed * Time.deltaTime;
        moveAmount = (circumference / 360);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checking if the door can be opened
        doorOpenable = gameController.doorOpen;

        //If the door can be opened
        if (doorOpenable == true)
        {
            doorManagement();
        }
	}

    //Function to manage the door opening and closing
    void doorManagement()
    {
        //Checking if the switch has been turned on
        doorSwitch = switchScript.switchOn;

        //if the switch turned on
        if (doorSwitch == true)
        {
            //Door will be opening or closing
            doorOpeningClosing = true;
        }

        //if the door is opening or closing
        if (doorOpeningClosing == true)
        {
            //if the door is closing
            if (doorOpenedClosed == true)
            {
                //Funciton callse to close the door
                closeDoor();
            }
            //else if the door is opening
            else if (doorOpenedClosed == false)
            {
                //Funciton called to open the door
                openDoor();
            }
        }
    }

    //Function to open the door
    void openDoor()
    {
        if (doorRotated != targetRotation)
        {
            if ((targetRotation - doorRotated) < rotationAmount)
            {
                transform.Rotate(0, 0, targetRotation - doorRotated);
                transform.Translate(-moveAmount * (targetRotation - doorRotated), 0, 0,Space.World);
                doorRotated += targetRotation - doorRotated;
            }
            else
            {
                transform.Rotate(0, 0, rotationAmount);
                transform.Translate(-moveAmount * rotationAmount, 0, 0, Space.World);
                doorRotated += rotationAmount;
            }
        }

        //When the door has finished opening
        if (doorRotated == targetRotation)
        {
            doorRotated = 0;
            doorOpenedClosed = true;
            doorOpeningClosing = false;
        }
    }

    //Funciton to close the door
    void closeDoor()
    {
        if (doorRotated != targetRotation)
        {
            if ((targetRotation - doorRotated) < rotationAmount)
            {
                transform.Rotate(0, 0, -(targetRotation - doorRotated));
                transform.Translate(moveAmount * (targetRotation - doorRotated), 0, 0, Space.World);
                doorRotated += targetRotation - doorRotated;
            }
            else
            {
                transform.Rotate(0, 0, -rotationAmount);
                transform.Translate(moveAmount * rotationAmount, 0, 0, Space.World);
                doorRotated += rotationAmount;
            }
        }

        //When the door has finished closing
        if (doorRotated == targetRotation)
        {
            doorRotated = 0;
            doorOpenedClosed = false;
            doorOpeningClosing = false;
        }
    }

}
