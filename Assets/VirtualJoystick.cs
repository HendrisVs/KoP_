using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
    private Image BackGroundImage;
    private Image JoystickImage;
    Vector3 inputVector;
    private Camera cam;
    private Canvas canvas;
    protected RectTransform background = null;
    private RectTransform handle = null;
    //Vector2 input = Vector2.zero;
    //Para Joystick
    private void Start()
    {
        //Vector2 center = new Vector2(0.5f, 0.5f);
        BackGroundImage = GetComponent<Image>();
        JoystickImage = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BackGroundImage.rectTransform,
                                                                    eventData.position,
                                                                    eventData.pressEventCamera,
                                                                    out position))
        {
            position.x = (position.x) / BackGroundImage.rectTransform.sizeDelta.x;
            position.y = (position.y) / BackGroundImage.rectTransform.sizeDelta.y;
            inputVector = new Vector3(position.x * 2 ,  position.y * 2, 0f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            // MoveJoystickImage
            JoystickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (BackGroundImage.rectTransform.sizeDelta.x/3),
                                                                        inputVector.y*(BackGroundImage.rectTransform.sizeDelta.y/3), 0
                                                                        );
            //Debug.Log(inputVector);
        }      
        //throw new System.NotImplementedException();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
    if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0)
        {
            return inputVector.y;
        }
        return Input.GetAxis("Vertical");
    }

    public Vector2 BothAxis()
    {
            return new Vector2 (inputVector.x, inputVector.y);
    }

    void OnMouseDown()
    {
        // load a new scene
        //Debug.Log("Mouse Down"); 
    }

    // Use this for initialization
}
