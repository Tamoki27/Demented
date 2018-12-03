using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour {
    float batteryLife;
    float maxBatlife = 30f;
    float minBatLife = 0f;

    private Slider batteryMeter;
    //FlashlightSwitch FLswitch;

    public Light flashlight;
    public bool isOn = false;
    // Use this for initialization
    void Start () {
        batteryMeter = GetComponent<Slider>();
        batteryLife = maxBatlife;
        //FLswitch = GetComponent<FlashlightSwitch>();
        flashlight = GetComponent<Light>();


    }

    // Update is called once per frame
    void Update () {
        Debug.Log(batteryLife);

        if (Input.GetKeyDown(KeyCode.F) /*&& batteryLife > minBatLife*/)
        {
            if (isOn)
            {
                //Debug.Log(FLswitch.isOn);

                flashlight.enabled = !flashlight.enabled;
                batteryLife += Time.deltaTime;
                isOn = false;

                if(batteryLife == maxBatlife)
                {
                    batteryLife = maxBatlife;
                }
            }

            if (!isOn)
            {
                flashlight.enabled = flashlight.enabled;
                isOn = true;
                batteryLife -= Time.deltaTime;
            }


        }

        batteryMeter.value = batteryLife;

    }
}
