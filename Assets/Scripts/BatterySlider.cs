using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour {
    float batteryLife;
    float maxBatlife = 30.0f;
    float minBatLife = 0f;

    int num = 0;
    public Slider batteryMeter;

    public Light flashlight;
    public bool isOn;
    public bool LightPower;
    // Use this for initialization
    void Start () {
        batteryLife = maxBatlife;
        isOn = false;
        LightPower = false;
        flashlight = GetComponent<Light>();


    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(num);
        if (LightPower == true)
        {
            //Debug.Log("Flashlight On: " + batteryLife);
            batteryLife -= Time.deltaTime;

            if(batteryLife <= 0)
            {
                batteryLife = minBatLife;
            }
        }

        if (LightPower == false)
        {
            //Debug.Log("Flashlight Off: " + batteryLife);
            batteryLife += Time.deltaTime;

            if (batteryLife >= maxBatlife)
            {
                batteryLife = maxBatlife;
            }
        }

        batteryMeter.value = batteryLife;


        if(batteryLife > 1)
        {
            //Debug.Log(LightPower);
            /*if (Input.GetKeyDown(KeyCode.F) && batteryLife <= 5)
            {
                flashlight.enabled = !flashlight.enabled;
                Debug.Log("Battery is drained");
            }*/
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Debug.Log("Toggle Light");
                if (LightPower == false)
                {
                    flashlight.enabled = flashlight.enabled = true;
                    LightPower = true;
                    num = 1;
                    //Debug.Log(LightPower);
                }
                else if (LightPower == true)
                {
                    flashlight.enabled = flashlight.enabled = false;
                    LightPower = false;
                    num = 2;
                    //Debug.Log(LightPower);
                }
            }
        }

        if(num == 1)
        {
            Debug.Log("Number is " + num);
        }
        else if(num == 2)
        {
            Debug.Log("Number is " + num);
        }

    }
}
