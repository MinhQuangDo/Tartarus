﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform CurCheckpoint;
    [SerializeField] private GameObject Player;
    public Component[] transformOfChilds;

    public float respawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (CurCheckpoint == null)
        {
            CurCheckpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        }
        Debug.Log(Player);
    }

    public IEnumerator RestartGame()
    {
        Player.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        Debug.Log(Player);
        Player.transform.position = CurCheckpoint.position;
        Player.SetActive(true);
    }

    // 
    void Restart()
    {
        StartCoroutine(RestartGame());
        transformOfChilds = GetComponentsInChildren<Transform>(true);

        foreach (Transform transf in transformOfChilds)
            transf.gameObject.SetActive(true);
        BroadcastMessage("Start");
        Debug.Log("Restarting");

    }
}
