using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    //public variables
    public int nPlayerSpotted = 0; // boolean to check if one drone has spotted the player
    public bool doorOpen = true; //Check if the doors are openable. 
    public bool gameWon = false;
    //Private Variables
    private GameObject[] drone;
    private DroneController[] droneController;
    private BoxCollider winArea;
    private GameObject player;
	// Use this for initialization
	void Start ()
    {
        //Getting components and game object for the drones
        drone = new GameObject[4];
        drone = GameObject.FindGameObjectsWithTag("Enemy");
        droneController = new DroneController[4];

        for (int i = 0; i < 4; i++)
        {
            droneController[i] = drone[i].GetComponent<DroneController>();
        }

        player = GameObject.FindGameObjectWithTag("Player");

        winArea = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameWon == false)
        {
            if (nPlayerSpotted != 4)
            {
                PlayerSpotted();
            }
            else
            {
                gameLost();
            }
        }
        else
        {
            gameWin();
        }
	}


    //Function to check how many drones have spotted the player
    void PlayerSpotted()
    {
        nPlayerSpotted = 0;
        for (int i = 0; i < 4; i++)
        {
            if (droneController[i].playerSeen == true)
            {
                nPlayerSpotted++;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Player has won");
            gameWon = true;
        }
    }

    //When the game has won
    void gameWin()
    {

    }

    //when the game is lost
    void gameLost()
    {
        doorOpen = false;
    }
}