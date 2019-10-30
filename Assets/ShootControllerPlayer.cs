using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControllerPlayer : MonoBehaviour {
    public float damageValueMissile;
    public OneShootTrigger oneShoot;
    public OneShootTrigger tripleShoot;
    public ProgressBarController ReadyToTripleShoot;
    public ProgressBarController ReadyToSimpleShoot;
    public GameObject missile;
    public Transform LeftMissile;
    public Transform CenterMissile;
    public Transform RightMissile;
    public Transform Player;
    public float forceShoot;
    public float ShootRate;
    public float angleMissile;
    public float qtyShoot;
    float nextShoot = 0f;
    // Use this for initialization
    void Start () {
        nextShoot = ShootRate + Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (readyToShoot() )
            {
            if (triggerOneShot())
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
          

           
        }
	}

    public void InstatiateMissile(Transform pos, float angleMissile)
    {
        float RotationPlayer = pos.eulerAngles.y;
        GameObject missileShooted = Instantiate(missile, pos.position, Quaternion.Euler(90f, RotationPlayer+ angleMissile, pos.rotation.z)) as GameObject; // Se gira por el prefab del laser
        
       missileShooted.GetComponent<MissileController>().damageValue = damageValueMissile;
        missileShooted.GetComponent<Rigidbody>().AddForce(missileShooted.transform.up * forceShoot);

        nextShoot = ShootRate + Time.time;
    }

    bool triggerOneShot()
    {
        float rateMissile = 100 / qtyShoot;

        if (oneShoot.OneTriggerPressed && ReadyToSimpleShoot.CurrentValue>= rateMissile)
            {
            ReadyToSimpleShoot.CurrentValue = ReadyToSimpleShoot.CurrentValue - rateMissile;
            return true;
            }
        
        return false;
    }
    bool triggerTripleShot()
    {
        if (tripleShoot.OneTriggerPressed && ReadyToTripleShoot.ReadyToShoot)
        {
            ReadyToTripleShoot.CurrentValue = 0;
            return true;
        }
        return false;
    }

    bool readyToShoot()
    {
        if (Time.time > nextShoot)
        {
            return true;
        }
        return false;
    }
}
