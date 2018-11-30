using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public bool DEBUG;
    public int maxHealth = 100;
    public int curHealth;

    public int level = 1;
    public int currExp = 0;
    public int exp = 100;

    public GameObject levelText;

    public GameObject DeathEffect;

    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        level = 1;
        curHealth = maxHealth;
        if (statusIndicator != null){
            statusIndicator.SetHealth(curHealth, maxHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DEBUG)
        {
            Debug.Log("Collision Detected: " + collision.gameObject);
        }
        Damage d = collision.gameObject.GetComponent<Damage>();
        if (d != null &&d.owner != Damage.ORIGIN.PLAYER)
        {
            damageCharacter(d.damageValue); // take damage as well
            HitEffect e = collision.gameObject.GetComponent<HitEffect>();
            if (e != null)
            {
                e.play(gameObject.transform.position, gameObject.transform.rotation);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DEBUG)
        {
            Debug.Log("Trigger Detected: " + collision.gameObject);
        }
        Damage d = collision.gameObject.GetComponent<Damage>();
        if (d != null && d.owner != Damage.ORIGIN.PLAYER)
        {
            damageCharacter(d.damageValue); // take damage as well
            HitEffect e = collision.gameObject.GetComponent<HitEffect>();
            if (e != null)
            {
                e.play(gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }

    public void damageCharacter(int damage) {

        curHealth -= damage;

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(curHealth, maxHealth);
        }
        if (curHealth <= 0)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
            curHealth = 0;
            Destroy(gameObject);
        }
    

    }

    public void levelUp(int expGain)
    {
        currExp += expGain;
        if(currExp >= exp)
        {
            level+=1;
            currExp = 0;
            //exp += 50;
            levelText.GetComponent<Text>().text = "LEVEL " + level;
            Debug.Log("Level " + level);
        }
    }

}
