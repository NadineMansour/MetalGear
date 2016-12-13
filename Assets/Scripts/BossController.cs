using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public GameObject target;
	public int minDistance;
	public float speed;

	private bool follow;
	private Animator animator;
	private int health;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		follow = false;
		health = 500;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position,target.transform.position)>minDistance)
    		follow = true;
		else 
			follow = false;
		if(follow){
			transform.LookAt(target.transform);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		animator.SetBool("bossMove", follow);
	}
}
