using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour
{
    //Public Variables
    public bool switchOn;
    //Private Variables
    private Animator anim;
    private BoxCollider col;
    private int switchOnHash = Animator.StringToHash("switchOn");
    private GameObject player;
	
    // Use this for initialization
	void Start ()
    {
        //Getting the components needed
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        switchOn = Input.GetButtonDown("Interact");
    }

    void OnTriggerStay(Collider other)
    {
        //If the game object is the player in the trigger collider
        if(other.gameObject == player)
        {
            //Setting animation
            anim.SetBool(switchOnHash, switchOn);
        }
    }
}
