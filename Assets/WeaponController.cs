using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = ((PlayerController)player.GetComponent(typeof(PlayerController)));
		Debug.Log(player);
		Debug.Log(player);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter (Collider col) 
	{
		Debug.Log(playerController);
		playerController.setCanCollectPistol(true);
	}

	void OnTriggerExit (Collider col) 
	{
		playerController.setCanCollectPistol(false);
	}
}
