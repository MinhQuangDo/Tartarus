using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
public class GetItem : MonoBehaviour
{
    [SerializeField] private string sendMessage;
    [SerializeField] private GameObject targetListener;


    public bool targetPlayer = true;

    // Start is called before the first frame update
    void Start()
    {   
        // Finds the player if the target is supposed to be the player
        if (targetPlayer)
        {
            targetListener = GameObject.FindGameObjectWithTag("Player");
        }
        // Sets the game object to true so the LevelManager will reload properly
        this.gameObject.SetActive(true);
    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            targetListener.SendMessage(sendMessage);
            // Item box should destroy itself post collision
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
