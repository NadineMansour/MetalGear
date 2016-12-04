using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public GameObject pistol, rifle;
	private float speed = 3.0f;
	private float crawlDirection = 0.0f;
	private bool walkForward, walkBackward, suspendMove, jump, crawlIdle, idleGun, idleRifle;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
			
		walkForward = false;
		walkBackward = false;
		crawlIdle = false;
		crawlDirection = 0.0f;
		jump = false;

		if (Input.GetKey("w")){
			//Walk forward
			walkForward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*2*Time.deltaTime);
			crawlDirection = 1.0f;
		}
		
		if (Input.GetKey("s")){
			//Walk backward
			walkForward = true;
			walkBackward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*2*Time.deltaTime);
			crawlDirection = -1.0f;
		}

		if (Input.GetKey("d")){
			//rotate clockwise
			transform.Rotate(Vector3.up * 50 * Time.deltaTime);
			walkForward = true;
		}
		

		if (Input.GetKey("a")){
			//rotate anti-clockwise
			transform.Rotate(Vector3.up * -50 * Time.deltaTime);
			walkForward = true;
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

		if (Input.GetKey("left shift")){
			crawlIdle = true;
			//transform.Translate (0, 0, Time.deltaTime);
		}

		if (Input.GetKey("space")){
			//jump
			jump = true;
		}
		
		pistol.active = idleGun;
		rifle.active = idleRifle;
		animator.SetBool("walkForward", walkForward );
		animator.SetBool("idleGun", idleGun );
		animator.SetBool("idleRifle", idleRifle );
		animator.SetBool("crawlIdle", crawlIdle );
		animator.SetBool("jump", jump);
		animator.SetFloat("crawlingDirection", crawlDirection);
		if(walkBackward){
			animator.SetFloat("walkingDirection", -1.0f );
		} else{
			animator.SetFloat("walkingDirection", 1.0f );
		}
	}
}
