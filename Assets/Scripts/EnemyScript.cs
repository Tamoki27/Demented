using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField]
    GameObject[] ewaypoint;

    Animator eAnim;


    //Follow
    public Transform target;

    //Patrol
    private UnityEngine.AI.NavMeshAgent agent;
    private int currentPoint = 0;
    private const float MIN_DISTANCE = 10;

    bool follow,arrived;
    int wayP;

    //for animation
    bool scream;
    float run;
    bool clearToMove;

    //Audio
    public GameObject aScream;
    public GameObject aAttack;

    int samp = 0;
    // Use this for initialization
    void Start () {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        eAnim = GetComponent<Animator>();
        follow = false;
        arrived = true;
        wayP = 0;
        run = 0.0f;
        clearToMove = true;

    }

    // Update is called once per frame
    void Update()
    {

        //setting the animation
        eAnim.SetBool("scream", scream);
        eAnim.SetFloat("run", run);

        //checking if he saw the player
        if (!follow)
        {
            //patrolling
            WaypointPatrol();
            if (run > 0f)
            {
                run -= 0.1f;
            }
        }
        else
        {
            //chasing player
            EnemyFunction();

        }


        //checking if animation is done
        AnimatorStateInfo animState = eAnim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Scream"))
        {
            aScream.GetComponent<AudioSource>().enabled = true;
            if (animState.normalizedTime > 0.9f)
            {
                scream = false;
            }
        }
        /*if(animState.IsName("Zombie Attack"))
        {
            aAttack.GetComponent<AudioSource>().enabled = true;
            if(animState.normalizedTime > 0.9f)
            {
                clearToMove = true;
            }
        }*/

        

        
    }

    void WaypointPatrol()
    {
        Debug.Log(ewaypoint.Length);
        Debug.Log("Waypoint Function activates");

        //checking the destination
        if (arrived)
        {
            Debug.Log("1 WP");
            wayP = Random.Range(0, ewaypoint.Length);
            arrived = false;
            
        }
        else
        {
            Debug.Log("2 WP");

            if ((transform.position - ewaypoint[wayP].transform.position).magnitude < MIN_DISTANCE)
            {
                arrived = true;
            }
            else
            {
                agent.SetDestination(ewaypoint[wayP].transform.position);

            }

        }
    }

    void EnemyFunction()
    {
        Debug.Log("EnemyFunction Activate");
        //To follow target
        if (scream)
        {
            Debug.Log("1 EF");
            agent.SetDestination(transform.position);
        }
        else
        {
            Debug.Log("2 EF");
            aScream.GetComponent<AudioSource>().enabled = false;

            if (clearToMove)
            {
                //Debug.Log((transform.position - target.transform.position).magnitude + " magnitude");

                agent.SetDestination(target.position);
                if (run < 1f)
                {
                    run += 0.1f;
                }

            }
            else
            {
                Debug.Log("!clearToMove");

                agent.SetDestination(transform.position);
                
            }
        }

        //attacking player
        if ((transform.position - target.transform.position).magnitude < 3)
        {
            Debug.Log("3 EF");
            clearToMove = false;
            eAnim.SetTrigger("attack");

            //applying damage
            AnimatorStateInfo animState = eAnim.GetCurrentAnimatorStateInfo(0);
            if (animState.IsName("Zombie Attack"))
            {
                aAttack.GetComponent<AudioSource>().enabled = true;
                if (animState.normalizedTime > 0.9f)
                {
                    samp++;
                    Debug.Log(samp + " testing");
                    gameObject.GetComponent<DamageScript>().DamagePlayer();

                }
            }

        }



    }

    public void FollowPlayer()
    {
        follow = true;
        scream = true;
        
    }

    public void BackToPatrol()
    {
        follow = false;
    }

   
}
