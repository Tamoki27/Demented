using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour {
    private Slider insanityMeter;
    private float insanityMax = 50f;
    private float insanityMin = 0f;
    private float insanityBase;

    public GameObject panel;
    public GameObject lose;

    private float timer = 300f;
	// Use this for initialization
	void Start () {
        insanityMeter = GetComponent<Slider>();
        insanityBase = insanityMax;
	}
	
	// Update is called once per frame
	void Update () {
        insanityMeter.value = insanityBase;
        //Debug.Log(timer);
        timer -= 1.0f;

        if(timer == 0)
        {
            insanityBase -= 5f;
            timer = 300f;
        }
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
