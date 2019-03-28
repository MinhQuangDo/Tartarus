using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField] private AudioClip[] levelMusic;
    private int curIndex = 0;
    /// <summary>
    /// Do not delete the music box
    ///  
    /// Music Box contains the different songs
    /// and diffent
    /// </summary>

    public void Awake()
    {

            MusicBox[] ArrayOfBoxes = (MusicBox[])FindObjectsOfType(typeof(MusicBox));
        Debug.Log(ArrayOfBoxes.Length);
            if(ArrayOfBoxes.Length > 1)
        {
            int i;
            for (i = 0; i < ArrayOfBoxes.Length; i++)
            {
                if( ArrayOfBoxes[i].gameObject != this.gameObject)
                {
                    DestroyImmediate(ArrayOfBoxes[i].gameObject);
                }
            }
        }
            DontDestroyOnLoad(transform.gameObject);
            
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
