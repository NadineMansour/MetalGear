using UnityEngine;
using System.Collections;

public class BulletsController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && gameObject.activeSelf){
			// Create the Bullet from the Bullet Prefab
			var bullet = (GameObject)Instantiate (bulletPrefab);
			bullet.transform.position = transform.position;
			bullet.transform.rotation = player.transform.rotation;

			// Add velocity to the bullet
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

			// Destroy the bullet after 2 seconds
			Destroy(bullet, 4.0f);
		}
	}
}
