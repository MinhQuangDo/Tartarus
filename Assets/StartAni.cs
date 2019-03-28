using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAni : MonoBehaviour
{
    public GameObject Player;
    public string ScriptName;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = Player.GetComponent<Animator>();
        Time.timeScale = 1;

        Debug.Log("playing");
    }

    // Update is called once per frame
    void Update()
    { 
        _anim.Play(ScriptName, -1, 0f);
        _anim.SetBool("start", true);
    }
}
