using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour {
    private Slider insanityMeter;
    private float insanityMax = 50f;
    private float insanityMin = 0f;
    public float insanityBase;

    public GameObject panel;
    public GameObject lose;

    private float timer = 1000f;
	// Use this for initialization
	void Start () {
        insanityMeter = GetComponent<Slider>();
        insanityBase = insanityMax;
	}
	
	// Update is called once per frame
	void Update () {
        insanityMeter.value = insanityBase;
        //Debug.Log(timer);
        //Timer goes down 1.0 per update
        timer -= 1.0f;
        
        //If timer is equal to 0 the meter goes down by 5 and resets the timer to enter the loop again
        if(timer == 0)
        {
            insanityBase -= 1f;
            timer = 1000f;
        }

        //if the meter goes down to 0 game would be over
        if(insanityMeter.value == insanityMin)
        {
            GameOver();

        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(false);
        lose.SetActive(true);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Antidote")
        {
            insanityBase += 25f;
        }
        
    }
}
