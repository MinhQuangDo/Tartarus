using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        //Don't fall until after the coroutine is done
        // Freeze rotation so the object does not move
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
