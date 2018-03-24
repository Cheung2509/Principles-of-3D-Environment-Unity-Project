using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{
    //Public Variables
    public float fieldOfViewAnlge = 110f;   //Variable to determine the drones field of view
    public bool playerInSight = false; //Variable to see if the player is in the sight of the drone

    //Private Variables
    private GameObject player;  //Gameobject used to reference the players location
    private SphereCollider col; //Reference to the sphere trigger collider
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Getting the player gameobject
        col = GetComponent<SphereCollider>();   //Getting the sphere collider component
	}

    //If an game object enters and stay in the sphere collider
    void OnTriggerStay (Collider other)
    {
        //if the game object is a player
        if (other.gameObject == player)
        {
            //Creating vector to get the field of view angle
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, -transform.up);
            //if the player is in the field of view
            if(angle < fieldOfViewAnlge * 0.5f)
            {
                //Creating ray cast
                RaycastHit hit;
                
                if (Physics.Raycast(transform.position - transform.up, direction.normalized, out hit,col.radius))
                {
                    //if the ray cast hit the player
                    if (hit.collider.gameObject == player)
                    {
                        //the player is in the drones sight
                        playerInSight = true;
                    }
                }
            }
        }
    }
}
