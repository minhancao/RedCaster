using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public enum ORIGIN {PLAYER, ENEMY, NONE}

    public ORIGIN owner = ORIGIN.NONE;

    public int damageValue = 0;


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "monster1")
    //    {

    //        if (DEBUG)
    //        {
    //            Debug.Log("Enemy Collision detected");
    //            Debug.Log("Damage Taken: ");
    //        }
    //        collision.gameObject.GetComponent<Health>().damage(damageValue);
    //        gameObject.GetComponent<CharacterStats>().damageCharacter(50); // take damage as well
    //    }
    //    else if (collision.gameObject.tag == "hazard")
    //    {
    //        if (DEBUG)
    //        {
    //            Debug.Log("Hazard Collision detected");
    //            Debug.Log("Damage Taken: ");
    //        }
    //    }
    //}

}
