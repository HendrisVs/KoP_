using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OneShootTrigger : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    public bool OneTriggerPressed;
    // Use this for initialization
    void Update()
    {
    if (OneTriggerPressed)
        {
            //Debug.Log("Disparando");
        }
    }

    public void  OnPointerUp(PointerEventData eventData)
    {
        OneTriggerPressed = false;
        //Debug.Log("OnPointerUp");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OneTriggerPressed = true;
    }



    }
