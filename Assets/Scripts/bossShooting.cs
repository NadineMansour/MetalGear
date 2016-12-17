using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour {
    GameObject boss;
    GameObject player;
	// Use this for initialization
	void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit bulletHit;

        if(Physics.Raycast(transform.position,boss.transform.forward,out bulletHit,20))
        {
            if (bulletHit.collider.tag == "Player")
            {
                player.gameObject.GetComponent<PlayerController>().health -= 10;
            }
        }
	}
}
