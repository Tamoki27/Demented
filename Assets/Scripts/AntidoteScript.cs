using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteScript : MonoBehaviour {

    float insanity;
    float addSanity = 100f;

    public GameObject[] Antidote;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            IncreaseInsanity(other);
        }
    }

    private void IncreaseInsanity(Collider player)
    {
        InsanityMeter im = player.GetComponent<InsanityMeter>();
        im.insanityBase += addSanity;
        
        Destroy(gameObject);

    }
}
