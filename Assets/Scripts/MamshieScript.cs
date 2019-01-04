using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamshieScript : MonoBehaviour {

    [SerializeField]
    GameObject[] ewaypoint;

    Animator eAnim;

    //Follow
    public Transform target;

    //Patrol
    private UnityEngine.AI.NavMeshAgent agent;
    private int currentPoint = 0;
    private const float MIN_DISTANCE = 3;

    bool follow,arrived;
    int wayP;

    //for animation
    bool scream;
    float run;
    bool clearToMove;


    // Use this for initialization
    void Start () {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        follow = false;
        arrived = true;
        wayP = 0;
        eAnim = GetComponent<Animator>();
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
            FollowMamshie();

        }


        //checking if animation is done
        AnimatorStateInfo animState = eAnim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Scream"))
        {
            Debug.Log("scream  " + scream);
            if (animState.normalizedTime > 0.9f)
            {
                Debug.Log("Update4");

                scream = false;
            }
        }
        if(animState.IsName("Zombie Attack"))
        {
            if(animState.normalizedTime > 0.9f)
            {
                clearToMove = true;
            }
        }

        

        
    }

    void WaypointPatrol()
    {
        //checking the destination
        if (arrived)
        {

            wayP = Random.Range(0, ewaypoint.Length);
            arrived = false;
            
        }
        else
        {

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

    void FollowMamshie()
    {
       
        //To follow target
        if (scream)
        {
            Debug.Log(scream + "scream");
            agent.SetDestination(transform.position);

        }
        else
        {
            if (clearToMove)
            {
                agent.SetDestination(target.position);
                if (run < 1f)
                {
                    Debug.Log(run + "run");
                    run += 0.1f;
                }
            }
            else
            {
                agent.SetDestination(transform.position);
            }
        }

        //attacking player
        if ((transform.position - target.transform.position).magnitude < MIN_DISTANCE)
        {
            clearToMove = false;
            eAnim.SetTrigger("attack");
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
