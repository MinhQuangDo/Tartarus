using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 16f;

    public bool movementMode = false;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // FixedUdate is called every physics update
    void FixedUpdate()
    {
        Vector2 totalForce = new Vector2(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        //Set the velocity equal to the totalForce
        rigidBody.velocity = totalForce;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidBody.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
