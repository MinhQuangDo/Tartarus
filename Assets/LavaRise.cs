using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    [SerializeField] private Collider2D curCollider;
    public Transform Ceiling;
    public float UpSpeed = 10;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curCollider.bounds.max.y <= Ceiling.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + UpSpeed, transform.position.z);
        }
        else
        {
            // Game Over?
            Debug.Log("GAME OVER MAN, GAME OVER!");
        }
    }
}
