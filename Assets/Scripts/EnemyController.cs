using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent enemy;
    public Transform target;
    private Animator anim;

    bool walk;
    bool stop;
    bool rotate;
    bool positveDirection;

    string stage;  

    float timer;
	// Use this for initialization
	void Start () {
        walk = false;
        stop = false;
        rotate = false;
        positveDirection = false;
        timer = 4;
        stage = "walk";

        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {       
        motionController();
        enemy.SetDestination(target.position);
        anim.SetBool("stop", stop);
        anim.SetBool("walk", walk);
        anim.SetBool("rotate", rotate);
    }

    void motionController()
    {
        if (stage == "idle")
        {
            Debug.Log("inside idle");
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"));
            timer -= Time.deltaTime;
            stop = true;
            walk = false;
            rotate = false;

            if(timer < 0)
            {
                timer = 1.5f;
                stage = "rotate"; 
            }
            
        }
        else if(stage == "rotate")
        {
            Debug.Log("inside rotate");
            rotate = true;
            walk = false;
            stop = false;
            timer -= Time.deltaTime;
            transform.Rotate(Vector3.up * 125 * Time.deltaTime);

            if (timer < 0)
            {
                timer = 4;
                rotate = false;
                walk = true;
                stop = false;
                stage = "walk";
                if (positveDirection)
                {
                    target.position = new Vector3(target.position.x, target.position.y, target.position.z + 10);
                    positveDirection = false;
                }
                else
                {
                    target.position = new Vector3(target.position.x, target.position.y, target.position.z - 10);
                    positveDirection = true;
                }
            }

            

            //check if rotation animation has ended
                //do somthing
        }
        else if (stage == "walk")
        {
            Debug.Log("inside walk");            
            walk = true;
            stop = false;
            rotate = false;
            if (transform.position.x == target.position.x && transform.position.z == target.position.z)
            {             
                stage = "idle";
                stop = true;
                rotate = false;
                walk = false;
            }
        }
    }
}
