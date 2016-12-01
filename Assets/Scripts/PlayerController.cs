using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private float speed = 3.0f;
	private bool walkForward, walkBackward, suspendMove, jump, crawlForward;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
			
		walkForward = false;
		walkBackward = false;
		crawlForward = false;
		jump = false;

		if (Input.GetKey("w")){
			//Walk forward
			walkForward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*2*Time.deltaTime);
		}
		
		if (Input.GetKey("s")){
			//Walk backward
			walkForward = true;
			walkBackward = true;
			transform.Translate (0, 0, Input.GetAxis("Vertical")*2*Time.deltaTime);
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

		if (Input.GetKey("left shift")){
			crawlForward = true;
			transform.Translate (0, 0, Time.deltaTime);
		}

		if (Input.GetKey("space")){
			//jump
			jump = true;
		}
	
		animator.SetBool("walkForward", walkForward );
		animator.SetBool("crawlForward", crawlForward );
		animator.SetBool("jump", jump);

		if(walkBackward){
			animator.SetFloat("walkingDirection", -1.0f );
		} else{
			animator.SetFloat("walkingDirection", 1.0f );
		}
	}
}
