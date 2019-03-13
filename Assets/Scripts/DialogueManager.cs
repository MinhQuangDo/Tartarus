using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject helicopter;
    public GameObject Player;
    public GameObject dBox;
    public Text dText;
    public bool dialogActive;
    private Queue<string> sentences;
    private Animator _anim;
    private Animator _anim2;
    private bool intro;
    private bool intropt2;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _anim = helicopter.GetComponent<Animator>();
        _anim2 = Player.GetComponent<Animator>();
        dBox.SetActive(false);
        intro = true;
        intropt2 = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Convo");
        dBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        int length = sentences.Count;
        StartCoroutine(Wait(length));
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dText.text = sentence;
    }
    
    void EndDialogue()
    {
        Debug.Log("Finished");
        if (intropt2)
        {
            _anim2.SetBool("trigger", true);
            intro = false;
            intropt2 = false;
        }
        if (intro)
        {
            intro = false;
            dBox.SetActive(false);
            _anim.SetBool("Trigger", true);
            intropt2 = true;
        }
        dBox.SetActive(false);
    }

    public IEnumerator Wait(int length)
    {
        for (int i = 0; i <= length; i++)
        {
            DisplayNextSentence();
            yield return new WaitForSeconds(3.1f);
        }
    }
}
