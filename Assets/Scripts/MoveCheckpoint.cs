using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheckpoint : MonoBehaviour
{
    private Transform CurCheckPoint;

    // Start is called before the first frame update
    void Start()
    { 
        CurCheckPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CurCheckPoint.transform.position = this.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
