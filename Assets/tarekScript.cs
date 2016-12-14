using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarekScript : MonoBehaviour {

	private Animator anim;
	public Transform gunLocation;
	public Transform lookPos;

	public Transform cameraRot;

	private bool aim; 
	private bool canAim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		aim = Input.GetMouseButton(0);

		gunLocation.transform.parent.transform.rotation = cameraRot.rotation;
		Debug.Log (gunLocation.transform.parent.transform.rotation.y);
		if (gunLocation.transform.parent.transform.rotation.y > 0.3f) {
			canAim = false;
		} else {
			canAim = true;
		}

	}

	void OnAnimatorIK(){
		handleAimLocation();
	}

	private void handleAimLocation(){
		if(aim && canAim) {
			anim.SetLookAtWeight (1);
			anim.SetLookAtPosition (lookPos.position);

			anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
			anim.SetIKPosition (AvatarIKGoal.RightHand, gunLocation.position);
			anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
			anim.SetIKRotation (AvatarIKGoal.RightHand, gunLocation.rotation);
		} else {
			anim.SetLookAtWeight (0);
			anim.SetIKPositionWeight (AvatarIKGoal.RightHand, 0);
			anim.SetIKRotationWeight (AvatarIKGoal.RightHand, 0);
		}
	}
}
