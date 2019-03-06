using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HarmPlayer : MonoBehaviour
{
    [SerializeField] private Transform CurCheckpoint;
  //  [SerializeField] public GameObject Player;
    [SerializeField] private GameObject LevelManager;
    // Start is called before the first frame update
    void Start()
    {

        if (LevelManager == null)
        {
            LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
        }
    }

    // REMEMBER TO SET THE Polygon COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {   // Moved the set the player to false in the LevelManager
            Debug.Log("Working");
            LevelManager.SendMessage("Restart");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
