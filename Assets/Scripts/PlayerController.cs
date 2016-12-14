﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public GameObject pistol, rifle;
    public GameObject uiManager;
	private float speed = 3.0f;
	private float crawlDirection = 0.0f;
	private float turningDirection = 0.0f;
	private bool walkForward, walkBackward, suspendMove, jump, crawlIdle, idleGun, idleRifle, turn,jumpForward;
	private bool canCollectPistol, canCollectRifle;
	private bool pistolCollected, rifleCollected;
	public GameObject collectablePistol, collectableRifle;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		canCollectRifle = false;
		canCollectPistol = false;
		pistolCollected = false;
		rifleCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		bool crouching  = false;
		walkForward = false;
		walkBackward = false;
		crawlIdle = false;
		turn = false;
		crawlDirection = 0.0f;
		jump = false;
		jumpForward = false;
		speed = 4.0f;

		if (Input.GetKey("c")){
			crawlIdle = true;
			crouching = true;
			if(idleRifle)
				speed = 1.5f;
			else
				speed = 2.0f;
		}

		if (Input.GetKey("w")){
			//Walk forward
			walkForward = true;
			jumpForward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*speed*Time.deltaTime);
			crawlDirection = 1.0f;
		}
		
		if (Input.GetKey("s")){
			//Walk backward
			walkForward = true;
			walkBackward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*speed*Time.deltaTime);
			crawlDirection = -1.0f;
		}

		if (Input.GetKey("d")){
			//rotate clockwise
			transform.Rotate(Vector3.up * 50 * Time.deltaTime);
			if(crouching || idleGun)
				walkForward = true;
			crawlDirection = 1.0f;
			turn = !walkForward;
			turningDirection = 1.0f;
		}
		
		if (Input.GetKey("a")){
			//rotate anti-clockwise
			transform.Rotate(Vector3.up * -50 * Time.deltaTime);
			if(crouching || idleGun)
				walkForward = true;
			crawlDirection = 1.0f;
			turn = !walkForward;
			turningDirection = -1.0f;
		}

		if (Input.GetKeyUp("g")){
			if(canCollectPistol && !pistolCollected) {
				((UIController)uiManager.GetComponent(typeof(UIController))).collectItem("Gun");
				pistolCollected = true;
				//pistolSelected();
				canCollectPistol = false;
				Destroy(collectablePistol);
			}	
		}

		if (Input.GetKeyUp("r")){
			//Debug.Log(canCollectRifle);
			if(canCollectRifle && !rifleCollected) {
				((UIController)uiManager.GetComponent(typeof(UIController))).collectItem("Rifle");
				rifleCollected = true;
				//rifleSelected();
				canCollectRifle = false;
				Destroy(collectableRifle);
			}
		}

		if (Input.GetKeyUp("k")){
			((UIController)uiManager.GetComponent(typeof(UIController))).collectItem("Key");
		}

		if (Input.GetKeyUp("m")){
			((UIController)uiManager.GetComponent(typeof(UIController))).displayCollectables();
		}

		if (Input.GetKey("space")){
			//jump
			jump = true;
		}

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ((UIController)uiManager.GetComponent(typeof(UIController))).Pause();
            //((UIController)uiManager.GetComponent(typeof(UIController))).GameOver();
        }
		
		if(crouching){
			idleGun = false;
		} 
		
		pistol.active = idleGun;
		pistol.transform.parent.gameObject.active = idleGun;
		rifle.active = idleRifle;
		rifle.transform.parent.gameObject.active = idleRifle;
		animator.SetBool("walkForward", walkForward );
		animator.SetBool("idleGun", idleGun );
		animator.SetBool("idleRifle", idleRifle );
		animator.SetBool("crawlIdle", crawlIdle );
		if(jump && jumpForward){
			animator.SetBool("jumpForward", jumpForward);
			animator.SetBool("jump", false);
		} else if (jump){
			animator.SetBool("jump", jump);
			animator.SetBool("jumpForward", false);
		} else {
			animator.SetBool("jumpForward", false);
			animator.SetBool("jump", false);
		}
		animator.SetBool("turn", turn );
		animator.SetFloat("crawlingDirection", crawlDirection);
		animator.SetFloat("turningDirection", turningDirection);
		if(walkBackward){
			animator.SetFloat("walkingDirection", -1.0f );
		} else{
			animator.SetFloat("walkingDirection", 1.0f );
		}
	}

	public void setCanCollectRifle(bool can){
		canCollectRifle = can;
	}

	public void setCanCollectPistol(bool can){
		canCollectPistol = can;
	}

	public void rifleSelected(){
		idleRifle = !idleRifle;
		if(idleGun)
			idleGun = false;
	}

	public void pistolSelected(){
		idleGun = !idleGun;
		if(idleRifle)
			idleRifle = false;
	}

}
