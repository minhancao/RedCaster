using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {

    public Transform firePoint;
    public GameObject fireball;
    public GameObject lightningMissel;
    public GameObject frostMissel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0)){
        //    FireBall();
        //}
        //if (Input.GetButtonDown("Lightning")){
        //    Lightning();
        //}
        //if (Input.GetButtonDown("Frost")){
        //    Frost();
        //}
	}

    public void FireBall(){
        Instantiate(fireball, firePoint.position, firePoint.rotation);

    }

    public void Lightning()
    {
        Instantiate(lightningMissel, firePoint.position, firePoint.rotation);

    }

    public void Frost()
    {
        Instantiate(frostMissel, firePoint.position, firePoint.rotation);

    }
}
