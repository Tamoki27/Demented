using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightSwitch : MonoBehaviour {

    public Light flashlight;
    public bool isOn = false;


    // Use this for initialization
    void Start()
    {
        flashlight = GetComponent<Light>();

        
    }

    // Update is called once per frame
    void Update () {
        //Toggle flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                flashlight.enabled = !flashlight.enabled;
                isOn = false;
            }

            if (!isOn)
            {
                flashlight.enabled = flashlight.enabled;
                isOn = true;
            }


        }
    }
}
