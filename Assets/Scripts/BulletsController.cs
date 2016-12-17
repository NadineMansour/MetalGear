using UnityEngine;
using System.Collections;

public class BulletsController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject player;    
	public float speed;
	public Light light;
	private AudioSource audioSource;
	private bool isActive;
    LineRenderer laser;    
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		light.enabled = false;
        laser = GetComponent<LineRenderer>();             
	}
	
	// Update is called once per frame
	void Update () {
		light.enabled = false;
        RaycastHit laserHit;
        laser.SetPosition(0,transform.position);

        if(Physics.Raycast(transform.position,player.transform.forward,out laserHit))
        {            
            float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - laserHit.transform.position.x, 2) + Mathf.Pow(transform.position.y - laserHit.transform.position.y,2));
            laser.SetPosition(1, player.transform.forward * distance + transform.position);
        }
        else
        {
            laser.SetPosition(1, player.transform.forward * 20 + transform.position);
        }

        
		if (Input.GetMouseButtonDown(0) && gameObject.activeSelf){					
			audioSource.Play();
			light.enabled = true;						
            //shooting using raycast
            RaycastHit hit;

            if(Physics.Raycast(transform.position,player.transform.forward,out hit,10))
            {
                //Debug.Log(hit.collider.tag);
                if(hit.collider.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyController>().health -= 10;
                }
                else if(hit.collider.tag == "Boss")
                {
                    GameObject boss = hit.transform.gameObject;
                    boss.GetComponent<BossController>().health -= 10;
                   // Debug.Log("boss: " + boss.GetComponent<BossController>().health);
                    boss.GetComponent<BossController>().canSee = true;
                }
            }

		}
	}


}
