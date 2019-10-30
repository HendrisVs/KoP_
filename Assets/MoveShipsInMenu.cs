using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShipsInMenu : MonoBehaviour
{
    public GameObject Corner1;
    public GameObject Corner2;
    public GameObject Corner3;
    public GameObject Corner4;
    public GameObject Corner5;
    public GameObject Corner6;
    public GameObject Corner7;
    public GameObject Corner8;
    List<GameObject> CoornerArray = new List<GameObject>();
    public Transform Target;
    public float smothSpeed = 0.125f;
    int index = 0;
    public float speed;
    Vector3 direction;
    float m_Angle;
    Quaternion targetAngle;
    public float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        CoornerArray.Add(Corner1);
        CoornerArray.Add(Corner2);
        CoornerArray.Add(Corner3);
        CoornerArray.Add(Corner4);
        CoornerArray.Add(Corner5);
        CoornerArray.Add(Corner6);
        CoornerArray.Add(Corner7);
        CoornerArray.Add(Corner8);
        Target = CoornerArray[index].transform;
        Vector3 direction = GetDirection(Target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 desiredPosition = Target.position;

        if (transform.position == desiredPosition)
        {
            index = Random.Range(0, 7);
            Target = CoornerArray[index].transform;
        }
        Vector3 direction = GetDirection(Target.transform.position);
        m_Angle = Mathf.Atan2(direction.x, direction.z) * 180 / Mathf.PI;
        targetAngle = Quaternion.Euler(0f, m_Angle, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, Time.deltaTime * angularVelocity);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }

    public Vector3 GetDirection(Vector3 positionTarget)
    {
        var heading = positionTarget - transform.position;
        var distance = heading.magnitude; ;
        var direction = heading / distance;
        return direction;
    }

}

