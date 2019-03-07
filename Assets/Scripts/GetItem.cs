using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
public class GetItem : MonoBehaviour
{
    [SerializeField] private string sendMessage;
    [SerializeField] private GameObject targetListener;
    [SerializeField] private GameObject InventoryManager;

    public GameObject inventoryObject = null; //Id equals -1 while not in the inventory system

    public bool targetPlayer = true;
    public bool uiItem = false;

    // Start is called before the first frame update
    void Start()
    {
        InventoryManager = GameObject.FindGameObjectWithTag("Inventory");
        // Finds the player if the target is supposed to be the player
        if (targetPlayer)
        {
            targetListener = GameObject.FindGameObjectWithTag("Player");
        }
        // Sets the game object to true so the LevelManager will reload properly
        this.gameObject.SetActive(true);
        InventoryManager.GetComponent<Inventory>().removeItem(inventoryObject);
        inventoryObject = null;
    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            targetListener.SendMessage(sendMessage);
            // Item box should destroy itself post collision
            if (uiItem)
            {
                inventoryObject = InventoryManager.GetComponent<Inventory>().AddItem( GetComponent<SpriteRenderer>() );
            }
            this.gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
