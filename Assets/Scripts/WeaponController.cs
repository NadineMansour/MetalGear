using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = ((PlayerController)player.GetComponent(typeof(PlayerController)));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter (Collider col) 
	{
		if (CompareTag("Pistol"))
		{
			playerController.setCanCollectPistol(true);
		} else if (CompareTag("Rifle"))
		{
			playerController.setCanCollectRifle(true);
		}
		
	}

	void OnTriggerExit (Collider col) 
	{
		if (CompareTag("Pistol"))
		{
			playerController.setCanCollectPistol(false);
		} else if (CompareTag("Rifle"))
		{
			playerController.setCanCollectRifle(false);
		}
	}
}
