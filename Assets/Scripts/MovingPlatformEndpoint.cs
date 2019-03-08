using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformEndpoint : MonoBehaviour
{
    public GameObject targetPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            targetPlatform.SendMessage("Switch");
        }
    }
}
