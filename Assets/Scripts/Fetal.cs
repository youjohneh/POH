using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fetal : MonoBehaviour {
    public GameObject charPanel;
    public GameObject buttonA;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Movement>().fetal = true;
            charPanel.SetActive(true);
            charPanel.GetComponent<Fader>().duration = 30.0f;
            charPanel.GetComponent<Fader>().fadeIn();
            buttonA.SetActive(true);
            buttonA.GetComponent<Fader>().fadeIn();
        }
    }
}
