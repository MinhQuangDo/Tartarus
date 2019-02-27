using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class HarmPlayer : MonoBehaviour
{
    [SerializeField] private Transform CurCheckpoint;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // REMEMBER TO SET THE BOX COLLIDER TO TRIGGER
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false);
            // Item box should destroy itself post collision
            StartCoroutine(RestartGame());
        }


    }

    private IEnumerator RestartGame()
    {
       yield return new WaitForSeconds(1f);
       Player.transform.position = CurCheckpoint.position;
       Player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
