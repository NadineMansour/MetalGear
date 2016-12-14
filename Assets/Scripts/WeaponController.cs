using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;
	private bool canCollectHealth;

	// Use this for initialization
	void Start () {
		playerController = ((PlayerController)player.GetComponent(typeof(PlayerController)));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

		if (Input.GetKeyUp("h")){
			if(canCollectHealth) {
				Debug.Log (this);
				Destroy(this.gameObject);
			}	
		}
	}

	void OnTriggerEnter (Collider col) 
	{
		if (col.CompareTag ("Player")) {
			Debug.Log (this);
			if (CompareTag("Pistol"))
			{
				playerController.setCanCollectPistol(true);
			} else if (CompareTag("Rifle"))
			{
				playerController.setCanCollectRifle(true);
			} else if (CompareTag("Health")){
				canCollectHealth = true;
				playerController.setCanCollectHealth(true);
			}
		}
	}

	void OnTriggerExit (Collider col) 
	{
		if (col.CompareTag ("Player")) {
			if (CompareTag("Pistol"))
			{
				playerController.setCanCollectPistol(false);
			} else if (CompareTag("Rifle"))
			{
				playerController.setCanCollectRifle(false);
			} else if (CompareTag("Health")){
				canCollectHealth = false;
				playerController.setCanCollectHealth(false);
			}
		}
	}
		
}
