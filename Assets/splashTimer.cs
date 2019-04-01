using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine;
using UnityEngine.UI;

public class splashTimer : MonoBehaviour
{
    public Stopwatch Timer;

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        if (obj != null)
        {
            obj.GetComponent<MusicBox>().pauseTimer();
            Timer = obj.GetComponent<MusicBox>().timer;
        }
       
        long milli = Timer.ElapsedMilliseconds;
        long seconds = milli / 1000;
        long minutes = seconds / 60;
        seconds = seconds % 60;
        GetComponent<Text>().text = "You escaped Tartarus within \n"+minutes.ToString()+" minutes "+seconds.ToString()+" seconds.";
    }
}
