using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour
{
    [SerializeField] private Collider2D curCollider;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Camera;

    public Transform Ceiling;
    public float UpSpeed = 10;
    // Start is called before the first frame update


    void Start()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        if(foundPlayer != null)
        {
            Player = foundPlayer.transform;
        }
        Ceiling = GameObject.FindGameObjectWithTag("Respawn").transform;
        GameObject foundCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (foundPlayer != null)
        {
            Camera = foundCamera;
        }
        else
        {
            Debug.Log(this + " cannot find the Camera. Camera is not tagged as Camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((curCollider.bounds.max.y >= Ceiling.transform.position.y) && (curCollider.bounds.max.y >= Player.position.y))
        {
            // Game Over?
            // Activate the Restart Game GUI from the Camera]
            Camera.SendMessage("RestartLevelGUI");
            Debug.Log("GAME OVER MAN, GAME OVER!");
           
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + UpSpeed, transform.position.z);
        }
    }
}
