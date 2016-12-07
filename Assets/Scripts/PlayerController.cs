using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public GameObject pistol, rifle;
	private float speed = 3.0f;
	private float crawlDirection = 0.0f;
	private float turningDirection = 0.0f;
	private bool walkForward, walkBackward, suspendMove, jump, crawlIdle, idleGun, idleRifle, turn,jumpForward;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
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
			if(crouching)
				walkForward = true;
			crawlDirection = 1.0f;
			turn = !walkForward;
			turningDirection = -1.0f;
		}

		if (Input.GetKey("g")){
			idleGun = !idleGun;
			if(idleRifle)
				idleRifle = false;
		}

		if (Input.GetKey("r")){
			idleRifle = !idleRifle;
			if(idleGun)
				idleGun = false;
		}

		if (Input.GetKey("space")){
			//jump
			jump = true;
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
}
