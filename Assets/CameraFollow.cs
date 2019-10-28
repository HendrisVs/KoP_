using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smothSpeed = 0.125f;
    public Vector3 offset;
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosirtion = Vector3.Lerp(transform.position, desiredPosition, smothSpeed);
        transform.position = smoothedPosirtion;
        //transform.LookAt(target);
    }


}
