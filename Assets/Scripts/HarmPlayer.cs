using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HarmPlayer : MonoBehaviour
{
    [SerializeField] private Transform CurCheckpoint;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (LevelManager == null)
        {
            LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
        }
    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerMovement playerAvatar;
            playerAvatar = Player.GetComponent<PlayerMovement>();
            if(playerAvatar.alive) {
                playerAvatar.Die();
            }
            // Item box should destroy itself post collision
            LevelManager.SendMessage("Restart");
        }

    }



    // Update is called once per frame
    void Update()
    {

    }
}
