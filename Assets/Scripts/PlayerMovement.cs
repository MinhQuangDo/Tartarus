﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] Animations;
    // 0 is the base, 1 is with jetpack, 2 is with boots
    [SerializeField] private Sprite[] PlayerSprites;
    private AudioSource deathNoise;
    // 0 is the base, 1 is with jetpack, 2 is with boots

    public float speed = 10f;
    public float jumpSpeed = 15.0f;

    private CapsuleCollider2D _collider;
    private Rigidbody2D rb;
    private Animator animatorObj;

    public bool alive = true;

    public bool canDoubleJump = false;
    public bool canDash = false;

    private bool grounded;
    private double jumpCount;
    private bool dash = false;
    private float dir = 1; // -1 = left, 1 = right
    private double dodgecount = 0;
    private Vector2 dodgevect;

    void applyRocket()
    {
        canDoubleJump = true;
        GetComponent<Animator>().runtimeAnimatorController = Animations[1];
        GetComponent<SpriteRenderer>().sprite = PlayerSprites[1];
    }

    void applyBoots()
    {
        canDash = true;
        GetComponent<Animator>().runtimeAnimatorController = Animations[2];
        GetComponent<SpriteRenderer>().sprite = PlayerSprites[2];
    }

    void Start()
    {
        deathNoise = GetComponent<AudioSource>();
        _collider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animatorObj = GetComponent<Animator>();
        if (canDoubleJump)
        {
            applyRocket();
        }
        if (canDash)
        {
            applyBoots();
        }
        // Start the timer
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        if (obj != null)
        {
            obj.GetComponent<MusicBox>().startTimer();
        }
    }

    void Update()
    {
        // Don't move if the player is dead
        if (alive) {
            float mvmt_X = Input.GetAxis("Horizontal") * speed;
            float mvmt_Y = Input.GetAxis("Vertical") * speed;
            animatorObj.SetFloat("speed", Mathf.Abs(mvmt_X)); //horizontal speed for animation, can be negative so use math.abs
            rb.velocity = new Vector2(mvmt_X, rb.velocity.y);
            grounded = false;

            Vector2 max = _collider.bounds.max;
            Vector2 min = _collider.bounds.min;
            MovingPlatform platform = null;
            Collider2D hit = Physics2D.OverlapArea(new Vector2(max.x - 0.1f, min.y - 0.1f), new Vector2(min.x + 0.1f, min.y - 0.2f)); // checks a small rectangle under the player for collisions
            if (hit)
            {
                if (!hit.isTrigger) // We should not be grounded underneath trigger colliders
                {
                    platform = hit.GetComponent<MovingPlatform>();
                    jumpCount = 0;
                    dash = false;
                    grounded = true;
                    animatorObj.SetBool("jump", false);
                }
                else
                {
                    grounded = false;
                }
            }
            else { grounded = false; }

            if (platform != null) {
                transform.parent = platform.transform;
            } else {
                transform.parent = null;
            }

            if (canDoubleJump)
            {
                if ((grounded || jumpCount <= 1) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0); // cancel out previous jump velocity to avoid multiplying forces
                    rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                    jumpCount += 1;
                    animatorObj.SetBool("jump", true);
                }
            }
            else if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }

            if (canDash && !dash && Input.GetKeyDown(KeyCode.Space))
            {
                dash = true;
                dodgecount = 10; // # of frames of dash
                dodgevect = new Vector2(mvmt_X, mvmt_Y); // current movement at frame that dash key is input at
                dodgevect.Normalize(); // give dodgevect magnitude of 1
            }
            if (dodgecount != 0)
            {
                dodgecount--;
                rb.velocity = dodgevect * (jumpSpeed * 1.5f);
            }

            if (!Mathf.Approximately(mvmt_X, 0)) // flip player over x axis when changing direction to make them face correct direction
            {
                dir = Mathf.Sign(mvmt_X);
                transform.localScale = new Vector3(dir * 1f, 1f, 1);
            }

        }
    }


    public void Die()
    {
        // Set alive to false
        alive = false;
        rb.velocity = Vector2.zero;
        transform.Rotate(new Vector3(0, 0, 90), Space.Self);
        deathNoise.Play();
        // Velicity to zero
    }


    public void Respawn()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        alive = true;

    }
}
