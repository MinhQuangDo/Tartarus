using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform CurCheckpoint;
    [SerializeField] private GameObject Player;
    public Component[] transformOfChilds;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (CurCheckpoint == null)
        {
            CurCheckpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        }

    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);
        Player.transform.position = CurCheckpoint.position;
        Player.GetComponent<PlayerMovement>().Respawn();

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
