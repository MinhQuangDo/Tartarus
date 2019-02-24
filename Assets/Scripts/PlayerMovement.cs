using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpSpeed = 12.0f;

    private BoxCollider2D _collider;
    private Rigidbody2D rb;
    //private Animator animatorObj;
    private bool grounded;

    void Start()
    {
        //_collider = GetComponent<CapsuleCollider2D>();
        _collider = GetComponent<BoxCollider2D>();
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
            grounded = true;
        }
        else
        {
            grounded = false;
        }


        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        Vector3 pScale = Vector3.one; // flip player over x axis when changing direction
        if (!Mathf.Approximately(mvmt_X, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(mvmt_X) * 1, 1, 1);
        }
    }
}