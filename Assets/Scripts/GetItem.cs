using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GetItem : MonoBehaviour
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string sendMessage;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Use the item sprite as the sprite for the Item box
        spriteRenderer.sprite = itemSprite;
       
    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage(sendMessage);
            // Item box should destroy itself post collision
            Destroy(this.gameObject);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
