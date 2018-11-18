using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float health = 100; //health this enemy has
    //public float damage = 20; //damage it does to main character
    public int experience;

    public CharacterStats character;
    public GameObject DeathEffect;

	// Use this for initialization
	void Start () {
		
	}

    public void damageToEnemy(float damage)
    {
        health -= damage;
        Debug.Log("Enemy took 20 dmg, Health: " + health);
        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            character.levelUp(experience);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Projectile3D proj = hitInfo.gameObject.GetComponent("Projectile3D") as Projectile3D;
        if (proj != null)
        {
            damageToEnemy(hitInfo.GetComponent<Damage>().damageValue);
        }

    }
}
