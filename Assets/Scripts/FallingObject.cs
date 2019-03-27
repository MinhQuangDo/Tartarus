using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private GameObject selfObject;
    private Vector3 savedPosition;

    public float waitTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        savedPosition = this.transform.position;
        selfObject = this.gameObject;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        //Don't fall until after the coroutine is done
        // Freeze rotation so the object does not move
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        StartCoroutine(SpawnAndDrop());
    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Instantiate(selfObject, savedPosition, this.transform.rotation);

            Destroy(this.gameObject, 0.02f);
        }


    }

    // Wait an amount of time
    // Save the current position to spawn in a new one once this one disappears
    // Turn on the gravity
    public IEnumerator SpawnAndDrop()
    {
        yield return new WaitForSeconds(waitTime);
        
        //     if(myHarmPlayer!= null ){
        //        newObject.GetComponent<HarmPlayer>().Player = myHarmPlayer.Player;
        //   }
        rigidbody.gravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
