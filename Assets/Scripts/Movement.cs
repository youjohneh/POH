using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour {
    [Header("Sprites")]
    public SpriteRenderer masterSprite;
    public Sprite s_still;
    public Sprite s_walk;
    public Sprite s_run;
    public Sprite s_jump;
    public Sprite s_fetal;
    public bool facingRight = true;
    public bool fetal=false;
    [Header("Movement")]
    public float speed;
    public float runSpeed;
    private Rigidbody2D body;


    [Header("Jumping")]
    public float jumpSpeed;
    public bool grounded;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private Vector2 velocity = Vector2.zero;

    [Header("Interaction")]
    public bool talking;
    public bool stopped;

    public GameObject menu;
    public bool paused;
	// Use this for initialization
	void Start () {
        masterSprite = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void Update()
    {
        if(fetal)
        {
            masterSprite.sprite = s_fetal;
        }
        if(talking && !stopped)
        {
            stopped = true;
            body.velocity = new Vector2(0,0);
        }

        //if (Input.GetAxis("Jump")>0 && !talking)
        //{
        //    if (grounded)
        //    {
        //        masterSprite.sprite = s_jump;
        //        body.AddForce(new Vector2(0, jumpSpeed));
        //        grounded = !grounded;
        //    }
        //}
        if (!Input.anyKey && Input.GetAxis("Horizontal") == 0 && grounded)
        {
            masterSprite.sprite = s_still;
        }
        if (!grounded && !fetal)
        {
            masterSprite.sprite = s_jump;
        }

        //if (Input.GetAxis("Cancel") > 0)
        //{
        //    if (!paused)
        //    {
        //        Pause();
        //        return;
        //    }
        //    else if(paused)
        //    {
        //        unpause();
        //        return;
        //    }
        //}
    }



    public void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (Input.GetAxis("Jump") > 0 && !talking)
        {
            if (grounded)
            {
                masterSprite.sprite = s_jump;
                body.velocity = (new Vector2(0, jumpSpeed));
                grounded = !grounded;
            }
        }

        float move = Input.GetAxis("Horizontal");
        if (!talking)
        {
            if (Input.GetAxis("Sprint")==1)
            {
                body.velocity = new Vector2(move * runSpeed, body.velocity.y);
                masterSprite.sprite = s_run;
            }
            else 
            {
                body.velocity = new Vector2(move * speed, body.velocity.y);
                masterSprite.sprite = s_walk;
            }
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        if(facingRight)
        {
            masterSprite.flipX = true;
        }
        else if (!facingRight)
        {
            masterSprite.flipX = false;
        }
    }




    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;
    }
    public void unpause()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        paused = false;

    }
}
