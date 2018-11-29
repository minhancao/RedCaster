using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int TotalHealth = 100;
    public int health = 100; //health this enemy has
    //public float damage = 20; //damage it does to main character
    public int experience;

    public CharacterStats character;
    public GameObject DeathEffect;


	// Use this for initialization
	void Start () {
        health = TotalHealth;
	}

    public virtual void damageToEnemy(int damage)
    {
        // need to add damage indicator
        health -= damage;
        Debug.Log("Enemy took 20 dmg, Health: " + health);
        if (health <= 0)
        {
            death();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Projectile3D proj = hitInfo.gameObject.GetComponent("Projectile3D") as Projectile3D;
        Damage damage = hitInfo.GetComponent<Damage>();
        if (proj != null && damage.owner == Damage.ORIGIN.PLAYER)
        {
            damageToEnemy(damage.damageValue);
        }

    }

    public virtual void death(){
        Instantiate(DeathEffect, transform.position, transform.rotation);
        character.levelUp(experience);
        Destroy(gameObject);
    }

}
