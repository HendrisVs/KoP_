using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoorControllerEnemyBots : MonoBehaviour {

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
        if (readyToShootInRateTime() && readyToShootInReloadEnergy() && EnemyInFront())
        {
            InstatiateMissile(CenterMissile, 0);
        }
        else
        {
            if (triggerTripleShot())
            {
                InstatiateMissile(LeftMissile, -angleMissile);
                InstatiateMissile(CenterMissile, 0);
                InstatiateMissile(RightMissile, angleMissile);
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
        nextShoot = ShootRate + Time.time;
    }

    bool EnemyInFront()
    {
       return RayCastAgentController();
      
    }
    bool readyToShootInRateTime()
    {
      
        if (Time.time > nextShoot)
        {
            return true;
        }
        return false;
    }


    bool readyToShootInReloadEnergy()
    {
        float rateMissile = 100 / qtyShoot;
        if (ValueOneShootProgress >= rateMissile)
        {
            ValueOneShootProgress = ValueOneShootProgress - rateMissile;
            return true;
        }
        return false;
    }
    bool triggerTripleShot()
    {
        return false;
        /*
        if (tripleShoot.OneTriggerPressed && ReadyToTripleShoot.ReadyToShoot)
        {
            ReadyToTripleShoot.CurrentValue = 0;
            return true;
        }
        return false;*/
    }

    bool RayCastAgentController()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        UnityEngine.AI.NavMeshAgent agent;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, rayCastMax, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            return true;
            //transform.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity =  new Vector3 (0f, 0f, newNavMeshSpeed);
         }
        return false;
    }
    void ProgressOneShoot()
    {
        if (ValueOneShootProgress < 100)
        {
            ValueOneShootProgress += speedProgressOneShoot * Time.deltaTime;
            ReadyToOneShoot = false;
        }
        else
        {
            ReadyToOneShoot = true;
        }
    }

    void ProgressTripleShoot()
    {

    }


}
