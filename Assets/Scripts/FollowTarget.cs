using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour 
{
	public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
   // Animator enemyAnim;
    //float run;
    //bool attk, start;

	
	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //enemyAnim = GetComponent<Animator>();
        //run = 0.0f;
        //attk = false;
       // start = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
        /*EnemyCondition();

        enemyAnim.SetFloat("run", run);
        enemyAnim.SetBool("attack", attk);
        */

        agent.SetDestination(target.position);
		
	}

    /*void EnemyCondition()
    {
        if (start)
        {
            Debug.Log("Start");
            if(run < 1)
            {
                run += .1f;
            }

            if(run == 0.5f)
            {
                agent.SetDestination(target.position);

            }
        }
        else
        {
            agent.SetDestination(transform.position);
            Debug.Log("Run" + run);

            if (run > 0)
            {
                Debug.Log("Run" + run);

                run -= .1f;
            }
        }
    }
    public void ActivateRUNAWAY()
    {
        start = true;
    }
    public void ActivateNORUNAWAY()
    {
        start = false;
    }*/
}
