using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour {

    public GameObject gui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelPassed();
        }
    }

    public void LevelPassed()
    {
        gui.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
	
}
