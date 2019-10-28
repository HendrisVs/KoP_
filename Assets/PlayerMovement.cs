using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VirtualJoystick joystick;
    Vector2 JoystickDirection;
    float m_Angle;
    Quaternion targetAngle;
    public float angularVelocity;
    public float limitForMovement;
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JoystickDirection = joystick.BothAxis();
        m_Angle = Mathf.Atan2(JoystickDirection.x, JoystickDirection.y) * 180 / Mathf.PI;
        //Debug.Log(m_Angle);
        if (m_Angle != 0)
        {
            movePlayer();
        }
    }

    void movePlayer()
    {
        targetAngle = Quaternion.Euler(0f, m_Angle, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, Time.deltaTime * angularVelocity);
        if (Mathf.Abs(JoystickDirection.x) > limitForMovement * 0.1f || Mathf.Abs(JoystickDirection.y) > limitForMovement * 0.1f)
        {
            transform.Translate(new Vector3(JoystickDirection.x, 0f, JoystickDirection.y) * speed * Time.deltaTime, Space.World);
        }

    }
}
