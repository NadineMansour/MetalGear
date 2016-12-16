using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    Transform midDoor;
    private float doorSpeed;
    private bool canMove, canOpen;

	// Use this for initialization;
	void Start () {
        foreach(Transform child in transform)
        {
            if (child.gameObject.CompareTag("MiddleDoor"))
            {
                midDoor = child;
            }
        }
        canMove = false;
        doorSpeed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("o"))
        {
            canMove = true;
        }
        if (canMove && canOpen)
        {
            midDoor.Translate(0, 0, doorSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.collider.tag);
        if (CompareTag ("LeftDoor")){
            canMove = false;
        }
    }

    public void setCanOpen(bool can)
    {
        this.canOpen = can;
    }
}
