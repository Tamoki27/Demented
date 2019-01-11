using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour {

    public GameObject gui;

    public void LevelPassed()
    {
        gui.gameObject.SetActive(true);
    }
	
}
