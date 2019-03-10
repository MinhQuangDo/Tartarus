using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    public Transform target;

    public float smoothTime = 0.2f;

    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                target = foundPlayer.transform;
            }
        }
    }

        // Late Update
        void LateUpdate () {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}
