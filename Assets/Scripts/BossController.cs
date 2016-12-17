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
    bool canSee;
    string stage;    

	private bool follow;
	private Animator animator;
	private int health;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();        
		follow = false;
		health = 500;
        player = GameObject.FindGameObjectWithTag("Player");
        stage = "go to player";
        boss = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target.transform.position = transform.position;        
        bossMove = false;
        canSee = false;
    }
	
	// Update is called once per frame
	void Update () {

        FieldOfView();
        motionControl();
        boss.SetDestination(target.transform.position);

        animator.SetBool("bossMove", bossMove);
	}


    void motionControl()
    {
        if(canSee)
        {
            Debug.Log("can see");
            bossMove = true;
            target.transform.position = player.transform.position;
            if(Vector3.Distance(transform.position,target.transform.position) > 3)
            {                
                target.transform.position = player.transform.position;
            }
            else
            {
                bossMove = false;
                target.transform.position = transform.position;
            }
            transform.LookAt(player.transform.position);
            
        }
        else
        {
            //bossMove = false;
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
            if (Physics.Raycast(rayPosition, direction, out hit, 8))
            {
                //Debug.Log(hit.collider.transform.position);            
                if (hit.collider.tag == "Player")
                {
                    canSee = true;
                    Debug.Log("shayfo ya nadine");                    
                }
                else
                {
                    canSee = false;
                }                
            }
        }
    }
}
