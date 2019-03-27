using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string CurrentSceneName;
    public string NextSceneName;
    public string MainMenuName = "Main Menu";

    // Start is called before the first frame update
    void Start()
    {
        GameObject findScene = GameObject.FindGameObjectWithTag("LoadScene");
        if(CurrentSceneName == "")
        {
            if(findScene != null)
            {
                CurrentSceneName = findScene.GetComponent<SceneLoader>().CurrentSceneName;
            }
            else
            {
                Debug.Log(this.gameObject + " has no Current Scene Name variable");
            }
        }
        if (NextSceneName == "")
        {
            if (findScene != null)
            {
                NextSceneName = findScene.GetComponent<SceneLoader>().NextSceneName;
            }
            else
            {
                Debug.Log(this.gameObject + " has no Next Scene Name variable");
            }
        }
        if (MainMenuName == "")
        {
            Debug.Log(this.gameObject + " has no Main Menu Name variable");
        }
    }
    
    // UI and buttons
    public void MainMenu()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        if(obj != null)
        {
            obj.GetComponent<MusicBox>().playTitle();
        }
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
        Debug.Log(collision);
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
