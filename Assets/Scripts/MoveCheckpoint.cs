using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MoveCheckpoint : MonoBehaviour
{
    private Transform CurCheckPoint;

    [SerializeField] private SpriteRenderer flagColor;

    public Color flashColor = Color.red;

    // Start is called before the first frame update
    void Start()
    { 
        CurCheckPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CurCheckPoint.transform.position = this.transform.position;
            StartCoroutine(FlashColor());
        }
    }

    IEnumerator FlashColor()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        flagColor.color = flashColor;
        yield return new WaitForSeconds(0.5f);
        flagColor.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        flagColor.color = flashColor;
        yield return new WaitForSeconds(0.5f);
        flagColor.color = Color.white;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
