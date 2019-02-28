using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // UI and buttons
    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    // REMEBER TO SET TO TRIGGER
    //Door for player and other colliders
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
