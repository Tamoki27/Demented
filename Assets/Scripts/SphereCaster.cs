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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if(Physics.SphereCast(origin, sphereRad, direction, out hit, maxDist, layer, QueryTriggerInteraction.Collide))
        {
            currentHitObj = hit.transform.gameObject;
            currHitDist = hit.distance;
            //gameObject.GetComponent<FollowTarget>().enabled = true;
            //gameObject.GetComponent<Patroller>().enabled = false;

            
             gameObject.GetComponent<MamshieScript>().FollowPlayer();

            



        }
        else
        {
            currHitDist = maxDist;
            currentHitObj = null;
            //gameObject.GetComponent<FollowTarget>().enabled = false;
            //gameObject.GetComponent<Patroller>().enabled = true;

            gameObject.GetComponent<MamshieScript>().BackToPatrol();
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin + direction * currHitDist, sphereRad);
    }
}
