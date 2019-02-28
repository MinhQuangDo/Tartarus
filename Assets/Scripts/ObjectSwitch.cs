using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour
{
   // [SerializeField] private GameObject target;

    public bool StartActive = true;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(StartActive);
    }

    public void SetTargetActive()
    {
        this.gameObject.SetActive(true);
    }

    public void SetTargetFalse()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
