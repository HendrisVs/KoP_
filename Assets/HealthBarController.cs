using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
  Transform EnemyPosition;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        angle = transform.parent.transform.rotation.y;
        RectTransform currentRectTransform = transform.GetComponent<RectTransform>();
        Vector3 rotationVector = new Vector3(90,  -angle, 0f);
        Quaternion newRotation = Quaternion.Euler(rotationVector);
        currentRectTransform.rotation = newRotation;
    }
}
