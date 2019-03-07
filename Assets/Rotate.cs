using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Simple Script to Rotate the Object
    public float swingAmount = 45f;
    private float currentRotation = 0f;
    private int rotateCount = 10;


    // Update is called once per frame
    void Update()
    {
        if (rotateCount != 0)
        {
            rotateCount--;
            currentRotation += swingAmount;
            transform.eulerAngles = new Vector3(0, 0, currentRotation);
        }
        else
        {
            rotateCount = 3;
            swingAmount = -swingAmount;
        }

    }
}
