using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger2 : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject treasure;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }
    private void Update()
    {
        if (treasure.activeSelf == false)
        {
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueCaveCutscene>().StartDialogue(dialogue);
        this.gameObject.SetActive(false);
    }

}
