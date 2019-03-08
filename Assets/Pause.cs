using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private bool Paused;
    [SerializeField] private GameObject pauseGUI;
    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
        pauseGUI.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Paused)
            {
                Paused = true;
                pauseGUI.SetActive(true);
                Time.timeScale = 0;

            }
            else
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
}
