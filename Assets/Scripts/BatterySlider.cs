using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour {
    float batteryLife;
    float maxBatlife = 100.0f;
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
       // Debug.Log("Battery life: " + (int)batteryLife);
       //if it's on battery life decreases
        if (LightPower == true)
        {
            //Debug.Log("Flashlight On: " + batteryLife);
            batteryLife -= Time.deltaTime;

            if(batteryLife <= 0)
            {
                batteryLife = minBatLife;
            }
        }
        //otherwise it recharges
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

        //as long as battery is greater than 10 it would lit up
        if(batteryLife > 10)
        {
            //Debug.Log("Outside input battery life : " + (int)batteryLife);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Debug.Log("Toggle Light");
                if (LightPower == false)
                {
                    flashlight.enabled = flashlight.enabled = true;
                    LightPower = true;
                    num = 1;
                    //Debug.Log("Flashlight meter: " + (int)batteryLife + LightPower);
                }
                else if (LightPower == true)
                {
                    flashlight.enabled = flashlight.enabled = false;
                    LightPower = false;
                    num = 2;
                    //Debug.Log("Flashlight meter: " + (int)batteryLife + LightPower);
                }
            }
        }//otherwise it automatically turns off and won't allow player to turn it on unless it's greater than 10
        else if(batteryLife < 2)
        {
            

            flashlight.enabled = flashlight.enabled = false;
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = flashlight.enabled = false;
            }

            //batteryLife += Time.deltaTime;
            LightPower = false;

        }
    }
}
