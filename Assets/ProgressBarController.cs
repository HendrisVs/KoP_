using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarController : MonoBehaviour {
    public Transform ImageToLoad;
    public float CurrentValue;
    public bool ReadyToShoot;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (CurrentValue < 100)
            {
            CurrentValue += speed * Time.deltaTime;
            ReadyToShoot = false;
            }
        else
            {
                ReadyToShoot = true;
            }
        ImageToLoad.GetComponent<Image>().fillAmount = CurrentValue / 100;
    }
}
