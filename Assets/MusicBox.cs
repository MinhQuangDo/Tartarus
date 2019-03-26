using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField] private AudioClip[] levelMusic;
    private int curIndex = 0;
    static public bool alreadySpawned = false;
    /// <summary>
    /// Do not delete the music box
    ///  
    /// Music Box contains the different songs
    /// and diffent
    /// </summary>

    public void Awake()
    {
        if (alreadySpawned)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            alreadySpawned = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        

    }

    public void playLevel()
    {
        SwitchClip(1);
    }

    public void playReverse()
    {
        SwitchClip(2);
    }

    public void playTitle()
    {
        SwitchClip(0);
    }

    public void SwitchClip(int index)
    {
        if (curIndex == index)
        {
            Debug.Log("Music Box: Audio Clip has not changed");
            return;
        }

        if (index < levelMusic.Length)
        {
            curIndex = index;
            GetComponent<AudioSource>().clip = levelMusic[index];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("Music Box: Index is out of bounds");
        }
    }

    public void ChangeVolume(float vol)
    {
        if ( (vol <= 1) && (vol >= 0) ) {
            GetComponent<AudioSource>().volume = vol;
        }
        else
        {
            Debug.Log("Music Box: Volume is out of range");
        }
    }




}
