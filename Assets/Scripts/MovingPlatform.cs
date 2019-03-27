using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
  public GameObject destination;
  public GameObject departure;
  float distance;
    [SerializeField] private float speed = 0.05f;
    bool reached = false;

  public void Update()
  {

  	if(!reached)
  	{
  		move (transform.position, destination.transform.position);
  	}
  	else
  	{
  		distance = Vector2.Distance(transform.position, departure.transform.position);
  		if(distance > 0.1)
  		{
  			move (transform.position, departure.transform.position);
  		}
  		else
  		{
  			reached = false;
  		}
  	}
  }

  void move(Vector3 pos, Vector3 towards)
  {
  	//Vector2 direction = (towards - pos).normalized;
  	//objectRigidBody.MovePosition(objectRigidBody.position + direction * 1f * Time.deltaTime);
  	transform.position = Vector3.MoveTowards(pos, towards, speed);
  }

    void Switch()
    {
        reached = true;
    }
}
