using UnityEngine;
using System.Collections;

public class DroneMovementManagement : MonoBehaviour
{
    //Public Variables
    public float moveSpeed = 3f;
    public float rotationSpeed = 1f;

    //Private Variabele;
    private float distanceFromWaypoint;
    private int waypointIndex = 0;
    private GameObject[] waypoint;
    private float rotation = 0f;
    private float targetRotation = 180f;
    // Use this for initialization
    void Start ()
    {
        waypoint = new GameObject[2];   //assigning an array of waypoints
        waypoint = GameObject.FindGameObjectsWithTag(name+"WayPoint");  //Referencing the waypoints.
	}

    // Update is called once per frame
    void Update()
    {
        MovementManganement();
    }

    //Function to manage the movement of the 
    void MovementManganement()
    {
        //Calculating the distance from the way point
        distanceFromWaypoint = Vector3.Distance(transform.position, waypoint[waypointIndex].transform.position);
        //if the drone arives at its destincation
        if (distanceFromWaypoint == 0)
        {
            //if the drone has not finished rotating
            if (rotation != targetRotation)
            {
                //Calling function to rotate the drone
                Rotation();
            }
            else
            {
                //Resetting rotation once finished
                rotation = 0;
                //Setting new destingations
                if (waypointIndex == 0)
                {
                    waypointIndex = 1;
                }
                else if (waypointIndex == 1)
                {
                    waypointIndex = 0;
                }
            }
        }
        else if (distanceFromWaypoint != 0)
        {
            //Move towards destination
            transform.position = Vector3.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        }

    }

    //Funciton to rotate the drone
    void Rotation ()
    {
        //Calculate the amount of rotation
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // if the rotation is not enough
        if (rotation != targetRotation)
        {
            //if the amount of rotation left is less the the amount of rotation per second
            if ((targetRotation - rotation) < rotationAmount)
            {
                //rotate what is left
                transform.Rotate(0, 0, targetRotation - rotation);
                rotation += targetRotation - rotation;
            }
            else
            {
                // rotate drone
                transform.Rotate(0, 0, rotationAmount);
                rotation += rotationAmount;
            }
        }
    }
}
