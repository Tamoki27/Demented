using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DamagePlayer(other);
        }
    }

    void DamagePlayer(Collider player)
    {
        InsanityMeter im = player.GetComponent<InsanityMeter>();
        im.insanityBase -= 20f;
    }
}
