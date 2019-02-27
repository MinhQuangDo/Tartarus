using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 15.0f;

    private CapsuleCollider2D _collider;
    private Rigidbody2D rb;
    //private Animator animatorObj;

    public bool canDoubleJump = false;
    public bool canDash = false;
    

    private bool grounded;
    private double jumpCount;
    private bool dash = false;
    private float dir = 1; // -1 = left, 1 = right
    private double dodgecount = 0;
    private Vector2 dodgevect;

    void applyRocket(){
      canDoubleJump = true;
    }

    void applyBoots(){
      canDash = true;
    }

    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //animatorObj = GetComponent<Animator>();
    }

    void Update()
    {
        float mvmt_X = Input.GetAxis("Horizontal") * speed;
        float mvmt_Y = Input.GetAxis("Vertical") * speed;
        //animatorObj.SetFloat("speed", Mathf.Abs(mvmt_X)); //horizontal speed for animation, can be negative so use math.abs
        rb.velocity = new Vector2(mvmt_X, rb.velocity.y);
        grounded = false;

        Vector2 max = _collider.bounds.max;
        Vector2 min = _collider.bounds.min;
        Collider2D hit = Physics2D.OverlapArea(new Vector2(max.x - 0.1f, min.y - 0.1f), new Vector2(min.x + 0.1f, min.y - 0.2f)); // checks a small rectangle under the player for collisions
        if (hit)
        {
            Debug.Log("GROUNDED");
            jumpCount = 0;
            dash = false;
            grounded = true;
        }
        else { grounded = false; }

        if (canDoubleJump)
        {
            if ((grounded || jumpCount <= 1) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) )
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // cancel out previous jump velocity to avoid multiplying forces
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                jumpCount += 1;
            }
        }
        else if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) )
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
        if (dodgecount != 0) {
            dodgecount--;
            rb.velocity = dodgevect * (jumpSpeed*1.5f);
        }

        if (!Mathf.Approximately(mvmt_X, 0)) // flip player over x axis when changing direction to make them face correct direction
        {
            dir = Mathf.Sign(mvmt_X);
            transform.localScale = new Vector3(dir * 1f, 1f, 1);
        }
    }
}
