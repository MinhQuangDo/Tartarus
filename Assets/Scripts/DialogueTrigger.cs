using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        this.gameObject.SetActive(false);
    }

}
