using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLava : MonoBehaviour
{
    private GameObject lava;
    private LavaRise lavaScript;

    public float UpSpeedVar;

    void Start()
    {
        lava = GameObject.FindGameObjectWithTag("Lava");
        lavaScript = lava.GetComponent<LavaRise>();
        lavaScript.UpSpeed = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lavaScript.UpSpeed = UpSpeedVar;
        }
}

