using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    //Public Variables
    public bool playerSeen = false; //Bool variable to see if the player has been seen 
    public float pillarMoveSpeed = 10f;
    //Private Variables
    private Animator anim; //Animator
    private int playerSpottedHash = Animator.StringToHash("playerSpotted");
    private PlayerDetection playerDetect; //Player Detection script
    private DroneMovementManagement droneMovement; //Drone movement script
    private Rigidbody rb;
    private GameObject Pillars;
    private float pilllarMove = 0;
    // Use this for initialization
	void Start ()
    {
        //Getting components of the drone
        anim = GetComponent<Animator>();
        playerDetect = GetComponent<PlayerDetection>();
        droneMovement = GetComponent<DroneMovementManagement>();
        rb = GetComponent<Rigidbody>();
        Pillars = GameObject.FindGameObjectWithTag(name + "Pillars");
	}
	
	// Update is called once per frame
    void Update ()
    {
        //Calling function to check whether the drone has seen the player
        checkPlayerSeen();
    }
    
    //Function to check if the drone has seen the player
    void checkPlayerSeen()
    {
        playerSeen = playerDetect.playerInSight;    //Checking another script to see if the player has been seen by the drone
        anim.SetBool(playerSpottedHash, playerSeen);    //Setting the animator bool with player seen
        //if the dronw has seen the player
        if (playerSeen == true)
        {
            droneMovement.enabled = false;  //Drone stops moving
            rb.isKinematic = false; //drone falls to the ground
            LowerPillars();
        }
    }

    //Function to lower pillars
    void LowerPillars()
    {
        float targetPillarMove = 3;
        float moveAmount = pillarMoveSpeed * Time.deltaTime;

        if (pilllarMove != targetPillarMove)
        {
            if (targetPillarMove - pilllarMove < pilllarMove)
            {
                Pillars.transform.Translate(Vector3.back *(targetPillarMove - pilllarMove));
                pilllarMove += targetPillarMove - pilllarMove;
            }
            else
            {
                Pillars.transform.Translate(Vector3.back * moveAmount);
                pilllarMove += moveAmount;
            }
        }

    }
}
