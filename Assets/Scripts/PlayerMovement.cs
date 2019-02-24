using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpSpeed = 12.0f;

    private CapsuleCollider2D _collider;
    private Rigidbody2D rb;
    //private Animator animatorObj;

    public bool canDoubleJump;
    public bool canDash;

    private bool grounded;
    private double jumpCount;
    private bool dash = false;
    private float dir = 1; // -1 = left, 1 = right

    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //animatorObj = GetComponent<Animator>();
    }

    void Update()
    {
        float mvmt_X = Input.GetAxis("Horizontal") * speed;
        //animatorObj.SetFloat("speed", Mathf.Abs(mvmt_X)); //horizontal speed for animation, can be negative so use math.abs
        rb.velocity = new Vector2(mvmt_X, rb.velocity.y);
        grounded = false;

        Vector2 max = _collider.bounds.max;
        Vector2 min = _collider.bounds.min;
        Collider2D hit = Physics2D.OverlapArea(new Vector2(max.x, min.y - 0.1f), new Vector2(min.x, min.y - 0.2f)); // checks a small rectangle under the player for collisions
        if (hit)
        {
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

        if ( !dash && Input.GetKeyDown(KeyCode.Space))
        {
            dash = true;
            //rb.AddForce(new Vector2(-1*dir, 0) * 1000, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(dir,0) * 100, ForceMode2D.Impulse);
        }

        if (!Mathf.Approximately(mvmt_X, 0)) // flip player over x axis when changing direction
        {
            dir = Mathf.Sign(mvmt_X);
            Debug.Log(dir.ToString());
            transform.localScale = new Vector3(dir * 0.75f, 0.75f, 1);
        }
    }
}