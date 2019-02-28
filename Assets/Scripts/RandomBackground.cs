using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundSprites;
    // Start is called before the first frame update
    void Start()
    {
        //Randomly select a background from our list of preselected backgrounds
        GetComponent<SpriteRenderer>().sprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];
    }


}
