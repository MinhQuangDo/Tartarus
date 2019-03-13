using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLava : MonoBehaviour
{
    public GameObject lava;
    public LavaRise lavaScript;

    public float UpSpeedVar;

    void Start()
    {
        lava = GameObject.FindGameObjectWithTag("Lava");
        lavaScript = lava.GetComponent<LavaRise>();
        lavaScript.UpSpeed = 0f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lavaScript.UpSpeed = UpSpeedVar;
        }
    }
}

