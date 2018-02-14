using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour {
    public AudioClip clip;
    public AudioSource Source;
    public float pitch;
    public float volume;
	// Use this for initialization
	void Start () {
        Source = GameObject.FindGameObjectWithTag("MusicBox").GetComponent<AudioSource>();
	}
	
public void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            Source.clip = clip;
            Source.pitch = pitch;
            Source.volume = volume;
            Source.Play();

        }
    }
}
