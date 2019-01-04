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


    // Use this for initialization
    void Start () {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        follow = false;
        arrived = true;
        wayP = 0;
        eAnim = GetComponent<Animator>();
        run = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(follow + " " + scream);

        if (follow == true)
        {
           
            FollowMamshie();
        }
        else if (!follow)
        {
            Debug.Log("follow");
            WaypointPatrol();
            if(run > 0)
            {
                run -= 0.1f;
            }
        }

        

        AnimatorStateInfo animState = eAnim.GetCurrentAnimatorStateInfo(0);
        if (animState.IsName("Scream"))
        {
            if (animState.normalizedTime > 0.9f)
            {
                scream = false;
            }
        }

        eAnim.SetBool("scream", scream);
        eAnim.SetFloat("run", run);

        //eAnim.SetTrigger("attack");
    }

    void WaypointPatrol()
    {
        
        if (arrived)
        {

            int rand = Random.Range(0, ewaypoint.Length);
            arrived = false;
            wayP = rand;
            
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
        Debug.Log(scream);
        //To follow target
        if (!scream)
        {
           
            agent.SetDestination(target.position);
            if(run < 1)
            {
                Debug.Log("yeah");
                run += 0.1f;
            }
        }
        else
        {
            agent.SetDestination(transform.position);
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
