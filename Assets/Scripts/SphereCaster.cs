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

        //checks if player hits the spherecast
        if(Physics.SphereCast(origin, sphereRad, direction, out hit, maxDist, layer, QueryTriggerInteraction.Collide))
        {
            currentHitObj = hit.transform.gameObject;
            currHitDist = hit.distance;

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
