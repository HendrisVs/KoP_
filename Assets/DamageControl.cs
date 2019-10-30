using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageControl : MonoBehaviour {
    Canvas barCanvas;
    static GameObject healthBar;

    // Use this for initialization
    void Start() {

     

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ColliderDetected(DamageInChildCollider childScript, Collider collider)
    {
        float damage = collider.gameObject.GetComponent<MissileController>().damageValue;
        if (transform.tag!="Player" && transform.tag!=collider.tag)
        {
            Debug.Log(transform.tag);
            Debug.Log(collider.tag);
            healthBar = transform.Find("CanvasHealthBar/HealthBG/HealthBar").gameObject;
            if (healthBar!=null)
            {
                Debug.Log("Existe barra");
                //Debug.Log(transform.tag);
              
                Image healthBarImage = healthBar.GetComponent<Image>();
                healthBarImage.fillAmount = healthBarImage.fillAmount - (damage / 100);
                if (healthBarImage.fillAmount<=0)
                    {
                    DestroyThisCharacter();
                    }
            }
            Destroy(collider.gameObject);
        }
       
    }

    public void CollisionDetected(DamageInChildCollider childScript, Collision collision)
    {
        Debug.Log("collision");
        Destroy(collision.gameObject);

    }
    void DestroyThisCharacter()
    {

        Destroy(transform.gameObject);
    }




}
