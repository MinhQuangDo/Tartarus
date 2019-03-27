using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueCaveCutscene : MonoBehaviour
{
    public GameObject helicopter;
    public GameObject Player;
    public GameObject dBox;
    public GameObject treasure;
    public GameObject bg;
    public Text dText;
    public bool dialogActive;
    private Queue<string> sentences;
    private Animator _anim;
    private Animator _anim2;
    private Animator _anim3;
    private bool intro;
    private bool intropt2;
    private bool intropt3;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _anim = helicopter.GetComponent<Animator>();
        _anim2 = Player.GetComponent<Animator>();
        _anim3 = bg.GetComponent<Animator>();
        treasure.SetActive(true);
        dBox.SetActive(false);
        intro = true;
        intropt2 = false;
        intropt3 = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        int length = sentences.Count;
        // StartCoroutine(Wait(length));
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dText.text = sentence;
    }

    void EndDialogue()
    {
        if (intropt2)
        {
            _anim.SetBool("trigger2", true);
            intro = false;
            intropt2 = false;
            intropt3 = true;
        }
        if (intro)
        {
            treasure.SetActive(false);
            _anim3.SetBool("trigger", true);
            intropt2 = true;
        }
        dBox.SetActive(false);
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        if (obj != null)
        {
            obj.GetComponent<MusicBox>().playReverse();
        }
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
