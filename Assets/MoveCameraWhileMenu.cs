using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWhileMenu : MonoBehaviour
{
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public Transform Target;
    List<GameObject> planetsArray = new List<GameObject>();
    Transform destiny;
    public float smothSpeed = 0.125f;
    public Vector3 offset;
    int index = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        planetsArray.Add(Mercury);
        planetsArray.Add(Venus);
        planetsArray.Add(Earth);
        planetsArray.Add(Mars);
        planetsArray.Add(Jupiter);
        planetsArray.Add(Saturn);
        planetsArray.Add(Uranus);
        planetsArray.Add(Neptune);
        Target = planetsArray[index].transform;

    }

        // Update is called once per frame
        void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 desiredPosition = Target.position + offset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smothSpeed);
        //transform.position = smoothedPosition;
        Debug.Log(transform.position);
        Debug.Log(desiredPosition);
        
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, step);
        if (transform.position == desiredPosition)
            {
          
            index++;
            if (index>7)
                {
                    index = 0;
                }
            Target = planetsArray[index].transform;
            }


        }
}
