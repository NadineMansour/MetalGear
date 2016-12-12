using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public GameObject target;
	public int minDistance;

	private bool follow;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		follow = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Vector3.Distance(transform.position,target.transform.position));
		if(Vector3.Distance(transform.position,target.transform.position)>minDistance)
    		follow = true;
		else
			follow = false;
		if(follow){
			transform.LookAt(target.transform);
			transform.Translate(Vector3.forward * Time.deltaTime);
		}
		animator.SetBool("bossMove", follow);
	}
}
