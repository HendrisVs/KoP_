using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoorControllerEnemyBots : MonoBehaviour {

    public float rayCastMax;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RayCastAgentController();
    }

    void RayCastAgentController()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        UnityEngine.AI.NavMeshAgent agent;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayCastMax, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //transform.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity =  new Vector3 (0f, 0f, newNavMeshSpeed);
         }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }




    }

}
