using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ColliderDetected(DamageInChildCollider childScript, Collider collider)
    {
        Debug.Log("child collided");
        Destroy(collider.gameObject);
    }

    public void CollisionDetected(DamageInChildCollider childScript, Collision collision)
    {
        Destroy(collision.gameObject);

    }



}
