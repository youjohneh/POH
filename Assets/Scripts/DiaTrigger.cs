using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaTrigger : MonoBehaviour {
    public GameObject charPanel;
    public GameObject PlayerControl;
    public string topic;
    public Text storyText;
    public bool talking;
    public bool end;
    private bool triggered = false;
    public GameObject heart;
    public AudioClip clip;
    public AudioSource dialogueSource;
    // Use this for initialization
    void Start () {
        PlayerControl = GameObject.FindGameObjectWithTag("Player");
        talking = false;
        heart = GameObject.FindGameObjectWithTag("Heartbeat");
        dialogueSource = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		//if(talking == true)
  //      {
  //          if(Input.anyKeyDown)
  //          { 
  //          PlayerControl.GetComponent<Movement>().talking = false;
  //          PlayerControl.GetComponent<Movement>().stopped = false;

  //          }
  //      }
    }

    public void OnTriggerEnter2D (Collider2D Other)
    {
        if (Other.gameObject == PlayerControl && !triggered)
        {
            PlayerControl.GetComponent<Movement>().talking = true;
            PlayerControl.GetComponent<AudioSource>().Play();
            storyText.text = topic;
            charPanel.GetComponent<Fader>().fadeIn();
            talking = true;
            triggered = true;
            PlayerControl.GetComponent<Movement>().grounded = false;
            heart.GetComponent<AudioSource>().pitch += 0.1f;
            dialogueSource.clip = clip;
            dialogueSource.Play();
            StartCoroutine(Talker());

        }
    }

    public void OnTriggerExit2D (Collider2D Other)
    {
        if (Other.gameObject == PlayerControl && triggered && !end)
        {

            //charPanel.GetComponent<Fader>().fadeOut();
            this.gameObject.SetActive(false);
            PlayerControl.GetComponent<Movement>().grounded = true;

        }
    }


    public IEnumerator Talker()
    {
        yield return new WaitForSeconds(clip.length);
        PlayerControl.GetComponent<Movement>().talking = false;
        PlayerControl.GetComponent<Movement>().stopped = false;
        charPanel.GetComponent<Fader>().fadeOut();


    }
}
