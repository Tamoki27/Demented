using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteScript : MonoBehaviour {

    InsanityMeter im;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(im.insanityBase);
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Antidote")
        {
            Debug.Log("Triggered");
            Destroy(col.gameObject);
            im.insanityBase += 25;
        }
        
    }
}
