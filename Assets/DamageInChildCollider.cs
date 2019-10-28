using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInChildCollider : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision enter collided log in child");
        //Debug.Log(transform.name);
        transform.parent.parent.GetComponent<DamageControl>().CollisionDetected(this, collision);
    }

    void OnTriggerEnter(Collider collider)
    {
       if (collider.tag!= transform.gameObject.tag) // destruye el colisionador si no es del mismo equipo o generado por el mismo equipo

        {
            transform.parent.parent.GetComponent<DamageControl>().ColliderDetected(this, collider);
        }
   
      
        //Debug.Log(transform.name);
        // transform.parent.GetComponent<DamageControl>().CollisionDetected(this);
    }

}
