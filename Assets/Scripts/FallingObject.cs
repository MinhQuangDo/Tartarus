using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    public float waitTime = 30f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        //Don't fall until after the coroutine is done
        // Freeze rotation so the object does not move
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        StartCoroutine(SpawnAndDrop());
    }

    // Wait an amount of time
    // Spawn another object in the same location
    // Turn on the gravity
    public IEnumerator SpawnAndDrop()
    {
        FallingObject newObject;
        yield return new WaitForSeconds(waitTime);
        newObject = Instantiate(this, this.transform.position, this.transform.rotation);
        HarmPlayer myHarmPlayer = GetComponent<HarmPlayer>();
   //     if(myHarmPlayer!= null ){
    //        newObject.GetComponent<HarmPlayer>().Player = myHarmPlayer.Player;
     //   }
        rigidbody.gravityScale = 1f;
    }


    // REMEMBER TO SET THE Polygon COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject, 10f);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
