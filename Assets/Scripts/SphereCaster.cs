using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCaster : MonoBehaviour {

    public GameObject currentHitObj;

    public float sphereRad;
    public float maxDist;
    public LayerMask layer;

    private Vector3 origin;
    private Vector3 direction;

    private float currHitDist;

    int ctr;

	// Use this for initialization
	void Start () {
        ctr = 1;
	}
	
	// Update is called once per frame
	void Update () {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<EnemyScript>().FollowPlayer();
        }

        if(Physics.SphereCast(origin, sphereRad, direction, out hit, maxDist, layer, QueryTriggerInteraction.Collide))
        {
            currentHitObj = hit.transform.gameObject;
            currHitDist = hit.distance;

            //gameObject.GetComponent<FollowTarget>().enabled = true;
            //gameObject.GetComponent<Patroller>().enabled = false;

            //ctr controls the FollowPlayer function
            if (ctr > 0)
            {
                gameObject.GetComponent<EnemyScript>().FollowPlayer();
                ctr--;
            }
            



        }
        else
        {
            currHitDist = maxDist;
            currentHitObj = null;
            //gameObject.GetComponent<FollowTarget>().enabled = false;
            //gameObject.GetComponent<Patroller>().enabled = true;

            ctr++;
            gameObject.GetComponent<EnemyScript>().BackToPatrol();
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin + direction * currHitDist, sphereRad);
    }
}
