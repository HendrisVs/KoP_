using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodController : MonoBehaviour {

    // Use this for initialization
    public GameObject Asteroid_A;
    public GameObject Asteroid_B;
    public GameObject Asteroid_C;
    public GameObject Asteroid_D;
    public GameObject Asteroid_E;
    public GameObject Asteroid_F;
    public GameObject Asteroid_G;
    public GameObject Asteroid_H;
    public int qtyAsteroids = 100;
    float radius;
    public float offsetRadius;
    // List<GameObject> asteroidsArray;
    List<GameObject> asteroidsArray = new List<GameObject>();
    void Awake()
    {
        radius = transform.position.x;

        asteroidsArray.Add(Asteroid_A);
        asteroidsArray.Add(Asteroid_B);
        asteroidsArray.Add(Asteroid_C);
        asteroidsArray.Add(Asteroid_D);
        asteroidsArray.Add(Asteroid_E);
        asteroidsArray.Add(Asteroid_F);
        asteroidsArray.Add(Asteroid_G);
        asteroidsArray.Add(Asteroid_H);

        for (int index = 0; index <= qtyAsteroids; index++)
        {
            InstatiateOneAsteriod();
        }
    }

    void InstatiateOneAsteriod()
    {
        float inputXCyrclef = 0.0f;
        float inputYCyrclef = 0.0f;
        float radTmp = Random.Range(radius - (offsetRadius / 2), radius + (offsetRadius / 2));
        //var rad = Mathf.Deg2Rad * ((Random.Range(radius - (offsetRadius / 2), radius + (offsetRadius / 2))) * 360f / segments);
        var rad = Mathf.Deg2Rad * ((Random.Range(0, 361) * 360f )/ 360);
        Vector3 point = new Vector3(Mathf.Sin(rad) * radTmp + inputXCyrclef, 4, Mathf.Cos(rad) * radTmp + inputYCyrclef);
        //points[i] = new Vector3(Mathf.Sin(rad) * radius + inputXCyrclef, 0, Mathf.Cos(rad) * radius + inputYCyrclef);
        GameObject asteroidTmp = asteroidsArray[Random.Range(0, asteroidsArray.Count)];
        GameObject AsteriodClone  = Instantiate(asteroidTmp, point, Quaternion.identity) as GameObject; // Se gira por el prefab del laser
        /*float torque = Random.Range(-3, 3);
        AsteriodClone.GetComponent<Rigidbody>().AddTorque(AsteriodClone.transform.up * torque );
         torque = Random.Range(-3, 3);
        AsteriodClone.GetComponent<Rigidbody>().AddTorque(AsteriodClone.transform.forward * torque);
         torque = Random.Range(-3, 3);
        AsteriodClone.GetComponent<Rigidbody>().AddTorque(AsteriodClone.transform.right * torque);*/

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
