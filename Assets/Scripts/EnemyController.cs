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
    bool distractedRunning;
    bool positveDirection;

    public bool distracted;
    public Vector3 distractionPosition;

    public string stage;  

    float timer;

    GameObject player;
	// Use this for initialization
	void Start () {
        walk = false;
        stop = false;
        rotate = false;
        positveDirection = false;
        distracted = false;
        timer = 4;
        stage = "walk";        
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");    
        distractionPosition = new Vector3(0,0,0);
        
	}
	
	// Update is called once per frame
	void Update () {
        FieldOfView();
        motionController();               
        enemy.SetDestination(target.position);
        anim.SetBool("stop", stop);
        anim.SetBool("walk", walk);
        anim.SetBool("rotate", rotate);
        anim.SetBool("running", distractedRunning);
        anim.SetBool("distracted", distracted);
    }

    void motionController()
    {
        Debug.Log(stage);
        if (stage == "idle")
        {
            timer -= Time.deltaTime;
            stop = true;
            walk = false;
            rotate = false;

            if (timer < 0)
            {
                timer = 1.5f;
                stage = "rotate";
            }

        }
        else if (stage == "rotate")
        {
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
        }   
        else if (stage == "walk")
        {
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
       if(stage == "distracted")
        {
            walk = false;
            stop = true;
            rotate = false;
            distractedRunning = false;        
            target.position = transform.position;
            transform.LookAt(distractionPosition);            
            stage = "distracted running";
        }
        else if(stage == "distracted running")
        {
            enemy.speed = 2;
            distractedRunning = true;
            walk = false;
            stop = false;
            rotate = false;
            target.position = distractionPosition;

            if (transform.position.x == target.position.x && transform.position.z == target.position.z)
            {                               
                stage = "distracted idle";
                timer = 4;                
                enemy.speed = 1;
            }

        }
       else if (stage == "distracted idle")
        {
            timer -= Time.deltaTime;
            stop = true;
            rotate = false;
            walk = false;            
            distractedRunning = false;

            if (timer < 0)
            {
                target.position = new Vector3(5, 0, 4);
                walk = true;
                stop = false;
                distractedRunning = false;
                rotate = false;                
                stage = "walking to path";                
            }            
        }
       else if(stage == "walking to path")
        {
            /*if(transform.position.x == target.position.x && transform.position.z == target.position.z)
            {                
                Vector3 Z4 = new Vector3(5, 0, 4);
                Vector3 Z6 = new Vector3(5, 0, -6);
                float angle1 = Vector3.Angle(Z4, transform.forward);
                float angle2 = Vector3.Angle(Z6, transform.forward);                
                if (angle1 <= angle2)
                {
                    target.position = new Vector3(5, 0, 4);
                }
                else
                {
                    target.position = new Vector3(5, 0, -6);
                }
                distracted = false;
                stage = "walk";


            }            */

            if(positveDirection)
            {
                target.position = new Vector3(5, 0, 8);
                positveDirection = false;
                stage = "walk";
                timer = 4;
                distracted = false;
            }
            else
            {
                target.position = new Vector3(5, 0, -2);
                positveDirection = true;
                distracted = false;
                stage = "walk";
                timer = 4;
            }
        }
        
    }

    void FieldOfView()
    {
        RaycastHit hit;
        Vector3 rayPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) - rayPosition;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < 60)
        {
            if (Physics.Raycast(rayPosition, direction, out hit, 10))
            {
                //Debug.Log(hit.collider.transform.position);            
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("emsek 7aramy");
                }
            }
        }
    }
}
