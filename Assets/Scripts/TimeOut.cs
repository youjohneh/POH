using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeOut : MonoBehaviour {
    public float timer;
    public float threshold;
    public bool idle;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey && Input.GetAxis("Horizontal")==0)
            {
                idle = true;
            }
        if (idle)
        {
            timer += Time.deltaTime;
            if(timer >= threshold)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            timer = 0;
        }
    }
}
