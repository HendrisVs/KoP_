using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {
    private Rigidbody rig;
    public float speed;
    // Use this for initialization
    public float forceShoot;
    private void Awake()
    {
        //rig = GetComponent<Rigidbody>();
    }

    void Start () {
    }



    public void DestroyMissile()
    {
        Destroy(this.gameObject);
        //Destroy(collision.gameObject);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
