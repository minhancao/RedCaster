using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health = 100;

    public void damage(float damage) {
        health -= damage;
        if (health < 0){
            Destroy(gameObject);
        }
    }
}
