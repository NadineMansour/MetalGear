using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShooting : MonoBehaviour {
    GameObject boss;
    GameObject player;

    public Light light;
    private AudioSource audioSource;
    float timer;
    // Use this for initialization
    void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");

        audioSource = GetComponent<AudioSource>();
        light.enabled = false;
        timer = 1;
    }

    // Update is called once per frame
    IEnumerator Example()
    {        
        yield return new WaitForSeconds(1000);        
    }

    void Update () {        
        timer -= Time.deltaTime;
        light.enabled = false;
        if(timer <= 0)
        {
            timer = 0.7f;
            RaycastHit bulletHit;
            //Debug.Log(timer);
            if (Physics.Raycast(transform.position, boss.transform.forward, out bulletHit, 20))
            {
                if (bulletHit.collider.tag == "Player")
                {
                    audioSource.Play();
                    light.enabled = true;
                    player.gameObject.GetComponent<PlayerController>().health -= 10;
                    //StartCoroutine(Example());
                  //  Debug.Log(player.gameObject.GetComponent<PlayerController>().health);
                }
            }
        }
        
	}
}
