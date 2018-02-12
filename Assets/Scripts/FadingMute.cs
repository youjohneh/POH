using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingMute : MonoBehaviour {
    public float aStart, aEnd, LerpValue, timer, duration;

    public bool isMuting = false, fadeoutBool = false;

    private AudioSource a;
	// Use this for initialization
	void Start () {
        a = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        a.volume = Mathf.Lerp(aStart, aEnd, LerpValue);

        if(isMuting)
        {
            timer += Time.deltaTime;
            LerpValue = (timer / duration);
        }

	}

    public void fadeOut()
    {
        aStart = 1;
        aEnd = 0;
        LerpValue = 0;
        timer = 0;
        isMuting = true;
    }
}
