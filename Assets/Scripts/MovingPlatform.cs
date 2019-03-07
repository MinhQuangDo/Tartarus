using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
  public GameObject destination;
  public GameObject departure;
  float distance;
  bool reached = false;
  Rigidbody2D objectRigidBody;

  public void Start()
  {
  	objectRigidBody = GetComponent<Rigidbody2D>();

  }

  public void Update()
  {
    Debug.Log(reached);
    Debug.Log(transform.position);
    Debug.Log(destination.transform.position);
    // if (transform.position == destination.transform.position)
    // {
    //   reached = true;
    // }

  	if(!reached)
  	{
  		move (transform.position, destination.transform.position);
      Debug.Log("to da right");
      // Debug.Log("yiki");
  	}
  	else
  	{
      Debug.Log("to da left");
  		distance = Vector2.Distance(transform.position, departure.transform.position);

  		if(distance > 0.1)
  		{
        // Debug.Log("yolo");
  			move (transform.position, departure.transform.position);
  		}
  		else
  		{
  			reached = false;
  		}
  	}
  }

  void move(Vector2 pos, Vector2 towards)
  {
  	Vector2 direction = (towards - pos).normalized;
  	objectRigidBody.MovePosition(objectRigidBody.position + direction * 1f * Time.deltaTime);
  	// transform.position = Vector3.MoveTowards(pos, towards, .1f);
  }

//   public void OnCollisionEnter2D(Collision2D other)
//   {
//   	reached = true;
//   }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("lol");
     if(collision.gameObject.tag == "Dest"){
             reached = true;
     }
   }
}
