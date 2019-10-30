using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoorControllerEnemyBots : MonoBehaviour {

    public float damageValueMissile;

    public float rayCastMax;
    public GameObject missile;
    public Transform LeftMissile;
    public Transform CenterMissile;
    public Transform RightMissile;
    public float forceShoot;
    public float ShootRate;
    public float angleMissile;
    public float qtyShoot;
    float nextShoot = 0f;

    public float ValueOneShootProgress;
    public float ValueTripleShootProgress;
    public float speedProgressOneShoot;
    public float speedProgressTripleShoot;
    public bool ReadyToOneShoot;

    // public OneShootTrigger oneShoot;
    //public OneShootTrigger tripleShoot;
    //public ProgressBarController ReadyToTripleShoot;
    //public ProgressBarController ReadyToSimpleShoot;
    // Use this for initialization
    void Start () {
        nextShoot = ShootRate + Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        ProgressOneShoot();
        ProgressTripleShoot();

        if (readyToShootInRateTime() && readyToOneShootInEnergy() && EnemyInFront())
        {
            InstatiateMissile(CenterMissile, 0);
            OneSimpleShotDone();
        }
        else
        {
            if (readyToShootInRateTime() && readyToTripleShootInEnergy() && EnemyInFieldView())
            {
                InstatiateMissile(LeftMissile, -angleMissile);
                InstatiateMissile(CenterMissile, 0);
                InstatiateMissile(RightMissile, angleMissile);
                OneTripleShotDone();
                // Debug.Log("un disparo TRIPLE");
            }
        }
        //RayCastAgentController();
    }


    public void InstatiateMissile(Transform pos, float angleMissile)
    {
        float RotationPlayer = pos.eulerAngles.y;
        GameObject missileShooted = Instantiate(missile, pos.position, Quaternion.Euler(90f, RotationPlayer + angleMissile, pos.rotation.z)) as GameObject; // Se gira por el prefab del laser
        missileShooted.GetComponent<Rigidbody>().AddForce(missileShooted.transform.up * forceShoot);
        missileShooted.GetComponent<MissileController>().damageValue = damageValueMissile;
        nextShoot = ShootRate + Time.time;
    }

    public bool EnemyInFieldView()
    {
        bool rayCastStatus = RayCastAgentTripleController();
        return rayCastStatus;
    }
    public bool EnemyInFront()
    {
        bool rayCastStatus = RayCastAgentController();
        return rayCastStatus;
    }
    public bool readyToShootInRateTime()
    {
      
        if (Time.time > nextShoot)
        {
            return true;
        }
        return false;
    }


    public bool readyToTripleShootInEnergy()
    {
        if (ValueTripleShootProgress >= 100)
        {
            return true;
        }
        return false;
    }

    public bool readyToOneShootInEnergy()
    {
        float rateMissile = 100 / qtyShoot;
        Debug.Log("rateMissile " + rateMissile);
        if (ValueOneShootProgress >= rateMissile)
        {
            return true;
        }
        return false;
    }

    public void OneSimpleShotDone()
    {
        float rateMissile = 100 / qtyShoot;
        ValueOneShootProgress = ValueOneShootProgress - rateMissile;
    }

    public void OneTripleShotDone()
    {
        ValueTripleShootProgress = 0;
    }

    public bool RayCastAgentTripleController()
    {

        Debug.Log("triple raycast");
        int layerMask = 1 << 13;
        RaycastHit hit;
        //UnityEngine.AI.NavMeshAgent agent;
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        Vector3 leftRayRotation = Quaternion.AngleAxis(-angleMissile, transform.up) * transform.forward;
        Vector3 rightRayRotation = Quaternion.AngleAxis(angleMissile, transform.up) * transform.forward;

        if (Physics.Raycast(transform.position, transform.TransformDirection(leftRayRotation) , out hit, rayCastMax, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(leftRayRotation) * hit.distance, Color.yellow);
            return true;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(rightRayRotation), out hit, rayCastMax, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(rightRayRotation) * hit.distance, Color.yellow);
            return true;
        }
        return false;

    }
    public bool RayCastAgentController()
    {
        int layerMask = 1 << 13;
        RaycastHit hit;
        //UnityEngine.AI.NavMeshAgent agent;
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayCastMax, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            return true;
         }
        return false;
    }
    void ProgressOneShoot()
    {
        if (ValueOneShootProgress < 100)
        {
            ValueOneShootProgress += speedProgressOneShoot * Time.deltaTime;
        }
    }
    void ProgressTripleShoot()
    {
        if (ValueTripleShootProgress < 100)
        {
            ValueTripleShootProgress += speedProgressTripleShoot * Time.deltaTime;
        }

    }
}
