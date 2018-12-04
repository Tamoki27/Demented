using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour {
    float batteryLife;
    float maxBatlife = 30f;
    float minBatLife = 0f;

    int count =  1;

    public Slider batteryMeter;
    //FlashlightSwitch FLswitch;

    public Light flashlight;
    private bool isOn = false;
    // Use this for initialization
    void Start () {
        //batteryMeter = GetComponent<Slider>();
        batteryLife = maxBatlife;
        //FLswitch = GetComponent<FlashlightSwitch>();
        flashlight = GetComponent<Light>();


    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(batteryLife);


        if (isOn)
        {
            batteryLife -= Time.deltaTime;
        }

        if (!isOn && count == 0)
        {
            batteryLife += Time.deltaTime;

            if (batteryLife == maxBatlife)
            {
                batteryLife = maxBatlife;
            }
        }

        batteryMeter.value = batteryLife;


        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(count);
            //batteryMeter.value = batteryLife;

            if (!isOn)
            {
                flashlight.enabled = flashlight.enabled;
                isOn = true;
                //batteryLife -= Time.deltaTime;
            }

            if (isOn)
            {
                flashlight.enabled = !flashlight.enabled;
                //batteryLife += Time.deltaTime;
                isOn = false;
                count = 0;

                /*if(batteryLife == maxBatlife)
                {
                    batteryLife = maxBatlife;
                }*/
            }

            



        }
        //Debug.Log(batteryLife);
        //Debug.Log(isOn);


        

        



        /*if (!isOn)
        {
            batteryLife += Time.deltaTime;

            if(batteryLife == maxBatlife)
            {
                batteryLife = maxBatlife;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = flashlight.enabled;
            }
        }

        if (isOn)
        {
            batteryLife -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = !flashlight.enabled;
            }
        }*/

    }
}
