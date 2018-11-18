using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellshield : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Spacebar") || shieldBarFill.barAmount <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //if (hitInfo.gameObject.layer == 11)//layer 11 is magic
        //{
        //    Fireball fire = hitInfo.gameObject.GetComponent("Fireball") as Fireball;
        //    if(fire != null)
        //    {
        //        Debug.Log("reverese");
        //        fire.reverseVelo();
        //    }
        //    Frost frost = hitInfo.gameObject.GetComponent("Frost") as Frost;
        //    if (frost != null)
        //    {
        //        frost.reverseVelo();
        //    }
        //    Lightning lightning = hitInfo.gameObject.GetComponent("Lightning") as Lightning;
        //    if (lightning != null)
        //    {
        //        lightning.reverseVelo();
        //    }
        //}
        //hitInfo.gameObject.GetComponent<Projectile3D>();
        Projectile3D proj = hitInfo.gameObject.GetComponent("Projectile3D") as Projectile3D;
        if(proj != null)
        {
            proj.reverseVelo();
        }

    }
}
