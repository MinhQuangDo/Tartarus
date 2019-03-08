using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;
    public string CurrentSceneName;
    public string NextSceneName;
    public string MainMenuName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // UI and buttons
    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }

    // UI and buttons
    public void NextLevel()
    {
        SceneManager.LoadScene(NextSceneName);
    }

    // UI and buttons
    public void RestartLevel()
    {
        SceneManager.LoadScene(CurrentSceneName);
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
