using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Component[] transformOfChilds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 
    void Restart()
    {
        transformOfChilds = GetComponentsInChildren<Transform>(true);

        foreach (Transform transf in transformOfChilds)
            transf.gameObject.SetActive(true);
        BroadcastMessage("Start");
        Debug.Log("Restarting");

    }
}
