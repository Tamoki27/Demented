using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    public GameObject player;

	

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Damage Works");
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        Debug.Log("This Function Works");
        //Debug.Log(player.GetComponent<InsanityMeter>().insanityBase);
        player.GetComponent<InsanityMeter>().insanityBase -= 10f;
        
    }
}
