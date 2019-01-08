using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour {
    //private Slider insanityMeter;
    private float insanityMax;
    private float insanityMin;
    public float insanityBase;

    public GameObject panel;
    public GameObject lose;
    public Image deathImage;
    public Image crackImage;
    public GameObject gui;

    public Image head;
    public Image brain;

    private Color c;

    private float ColorR = 167f;
    private float ColorG = 167f;
    private float ColorB = 167f;
    private float ColorA = 1f;


    private float timer = 1f;
	// Use this for initialization
	void Start () {
        //insanityMeter = GetComponent<Slider>();
        insanityBase = 0f;
        insanityMax = 1000f;
        insanityMin = 0f;
        insanityBase = insanityMax;
    }
	
	// Update is called once per frame
	void Update () {
        //insanityMeter.value = insanityBase;
        //Debug.Log("Insanity meter: " + insanityMeter.value);
        Debug.Log("Insanity Meter: " + insanityBase);


        //Timer goes down 1.0 per update
        timer -= Time.deltaTime;
        
        //If timer is equal to 0 the meter goes down by 1 and resets the timer to enter the loop again
        if(timer <= 0)
        {
            insanityBase -= 1f;
            timer = 1f;
        }

        //Setting the crack image when insanity base goes half in value
        if(insanityBase == (insanityMax * 0.5f))
        {
            //Debug.Log("Firing");
            crackImage.gameObject.SetActive(true);
        }

        if(insanityBase < (insanityMax * 0.3f))
        {
            Debug.Log("Check");
            bool check = true;
            if (check)
            {
                Debug.Log("Check1");

                head.gameObject.SetActive(true);
                check = false;
            }else if (!check)
            {
                Debug.Log("Check2");

                head.gameObject.SetActive(false);
                check = true;
            }
        }

        //Setting image alpha 
      
        ColorA = insanityBase/insanityMax;
        //Debug.Log(brain.GetComponent<Image>().color);
        brain.GetComponent<Image>().color = new Color(ColorR, ColorG, ColorB, ColorA);

        //if the meter goes down to 0 game would be over
        if (insanityBase <= insanityMin)
        {
            GameOver();

        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(false);
        lose.SetActive(true);
        deathImage.gameObject.SetActive(true);
        gui.SetActive(false);
    }

    public float GetInsanityBase()
    {
        return insanityBase;
    }

    public void SetInsanityBase(float sInsanityBase)
    {
        insanityBase = sInsanityBase;
    }
}
