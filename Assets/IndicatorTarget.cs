using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorTarget : MonoBehaviour {

    public Transform Target;
    public float HideDistance;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        var dir = Target.position - transform.position;
        if (dir.magnitude < HideDistance)
        {
            setChildrenActive(false);
        }
            else
        {
            setChildrenActive(true);
        }
           
    
       
        var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

    void setChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
