using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent boss;
    GameObject player;
    public GameObject target;
	public int minDistance;
	public float speed;

    public bool bossMove;
    bool turn;
    public bool canSee;
    string stage;    

	private bool follow;
	private Animator animator;
	public int health;
    float timer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();        
		follow = false;
		health = 500;
        player = GameObject.FindGameObjectWithTag("Player");
        stage = "back to position";
        boss = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target.transform.position = transform.position;        
        bossMove = false;
        canSee = false;
        turn = true;
        timer = 3;
    }
	
	// Update is called once per frame
	void Update () {        
        motionControl();
        animator.SetBool("bossMove", bossMove);
        animator.SetBool("turn", turn);
        FieldOfView();
        boss.SetDestination(target.transform.position);        

    }
    void LateUpdate()
    {
        motionControl();
    }

        void motionControl()
    {
        if(canSee)
        {
            stage = "";            
            bossMove = true;
            turn = false;
            target.transform.position = player.transform.position;
            timer = 3;           
            if(Vector3.Distance(transform.position,target.transform.position) > 3)
            {                
                target.transform.position = player.transform.position;
            }
            else
            {                      
                bossMove = false;
                turn = false;
                target.transform.position = transform.position;
            }
            transform.LookAt(player.transform.position);
            
        }
        else
        {
            timer -= Time.deltaTime;
            target.transform.position = transform.position;
            bossMove = false;
            turn = false;          
            if(timer <= 0)
            {
                stage = "back to position";
            }
        }

        if(stage == "back to position")
        {                       
            bossMove = true;
            turn = false;
            target.transform.position = new Vector3(0,transform.position.y,0);            

            if(transform.position == target.transform.position)
            {
                bossMove = false;
                turn = true;
            }
        }

    }

    void FieldOfView()
    {
        RaycastHit hit;
        Vector3 rayPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 direction = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) - rayPosition;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < 80)
        {
            if (Physics.Raycast(rayPosition, direction, out hit,10))
            {                                    
                if (hit.collider.tag == "Player")
                {                                      
                    canSee = true;                                       
                }
                else
                {                    
                    canSee = false;
                }
            }
        }                
    }
}
