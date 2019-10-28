using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEnemyMovement : MonoBehaviour {
    public float newNavMeshSpeed = 5.0f;
    public float PercentVelocityInHill = 30.0f;
    public GameObject nearEnemy;
    Vector3 NextGoalPosition;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("NavMesh");
        UnityEngine.AI.NavMeshAgent agent;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = newNavMeshSpeed * PercentVelocityInHill * 0.01f;
        NextGoalPosition = new Vector3 (nearEnemy.transform.position.x, 3.0f, nearEnemy.transform.position.z);
        transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = NextGoalPosition;
    }
}
