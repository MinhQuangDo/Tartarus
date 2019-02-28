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
        Debug.Log("I AM BACK"+this.gameObject.tag);
        if (targetPlayer)
        {
            targetListener = GameObject.FindGameObjectWithTag("Player");
        }
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
