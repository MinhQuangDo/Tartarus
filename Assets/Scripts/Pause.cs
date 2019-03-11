using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private bool Paused;
    [SerializeField] private bool GameOver;
    [SerializeField] private GameObject pauseGUI;
    [SerializeField] private GameObject restartGUI;
    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
        GameOver = false;
        pauseGUI.SetActive(false);
        restartGUI.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Paused && !GameOver)
            {
                Paused = true;
                pauseGUI.SetActive(true);
                Time.timeScale = 0;

            }
            else if(Paused && !GameOver)
            {
                Paused = false;
                pauseGUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        Paused = false;
        pauseGUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartLevelGUI()
    {
        GameOver = true;
        pauseGUI.SetActive(false);
        restartGUI.SetActive(true);
        Time.timeScale = 0;
    }
}
