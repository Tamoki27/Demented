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
        Debug.Log("Battery life: " + (int)batteryLife);
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


        if(batteryLife > 10)
        {
            Debug.Log("Outside input battery life : " + (int)batteryLife);
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
                    Debug.Log("Flashlight meter: " + (int)batteryLife + LightPower);
                }
                else if (LightPower == true)
                {
                    flashlight.enabled = flashlight.enabled = false;
                    LightPower = false;
                    num = 2;
                    Debug.Log("Flashlight meter: " + (int)batteryLife + LightPower);
                }
            }
        }else if(batteryLife < 10)
        {
            /*float count = 0f;
            count += Time.deltaTime;
            Debug.Log("count :" + (int)count);
            do
            {
                if (count < 50)
                {
                    flashlight.enabled = flashlight.enabled = false;
                    Debug.Log("Light power: " + LightPower);
                    Debug.Log("Battery Meter :" + batteryLife);
                }
                else if (count > 50)
                {
                    count = 0f;

                }
            } while (batteryLife < 10);*/

            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = flashlight.enabled = false;
            }

            batteryLife += Time.deltaTime;


        }
    }
}
