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
    public bool isOn;
    public bool LightPower;
    // Use this for initialization
    void Start () {
        //batteryMeter = GetComponent<Slider>();
        batteryLife = maxBatlife;
        isOn = false;
        LightPower = false;
        //FLswitch = GetComponent<FlashlightSwitch>();
        flashlight = GetComponent<Light>();


    }

    // Update is called once per frame
    void Update () {

        if (LightPower == true)
        {
            Debug.Log("Flashlight On: " + batteryLife);
            batteryLife -= Time.deltaTime;
        }

        if (LightPower == false)
        {
            Debug.Log("Flashlight Off: " + batteryLife);
            batteryLife += Time.deltaTime;

            if (batteryLife >= maxBatlife)
            {
                batteryLife = maxBatlife;
            }
        }

        batteryMeter.value = batteryLife;


        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Toggle Light");
            //batteryMeter.value = batteryLife;

            if (LightPower == false)
            {
                flashlight.enabled = flashlight.enabled = true;
                LightPower = true;
                //batteryLife -= Time.deltaTime;
            }
            else if (LightPower == true)
            {
                flashlight.enabled = flashlight.enabled = false;
                //batteryLife += Time.deltaTime;
                LightPower = false;
                //count = 0;

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
