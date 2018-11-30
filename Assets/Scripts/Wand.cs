using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Transform shieldPoint;
    public Transform firePoint;
    public GameObject spellShieldBar;
    public GameObject spellShieldBarFill;
    public GameObject spellShield;
    public GameObject fireball;
    public GameObject lightningMissel;
    public GameObject frostMissel;

    public GameObject teleportEffect;

    public float damage = 10;
    public LayerMask notToHit;

    float timeToFire = 0;
    CharacterController2D controller;
    GameObject character;

    public Sprite[] swords;
    public GameObject swordPrefab;
    public GameObject spellCircle;
    public GameObject swordSpriteMask;

    void Awake()
    {
        firePoint = transform.Find("Firepoint");
        if(firePoint == null)
        {
            Debug.LogError("No Firepoint");
        }
    }

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        controller = character.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            FireBall();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            RandomSwords();
        }
        //if (Input.GetButtonDown("Lightning"))
        //{
        //    Lightning();
        //}
        //if (Input.GetButtonDown("Frost"))
        //{
        //    Frost();
        //}
    }

    void SpellShield()
    {
        Vector3 help = shieldPoint.position;
        help.x -= 0.6f;
        Instantiate(spellShield, firePoint.position, firePoint.rotation);
        Instantiate(spellShieldBar, shieldPoint.position, shieldPoint.rotation);

        if(!CharacterController2D.m_FacingRight)
        {
            help.x += 1.2f;
        }
            Instantiate(spellShieldBarFill, help, shieldPoint.rotation);
        
    }

    public void FireBall()
    {
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

    public void Teleport(){

        Animation anim = character.GetComponent<Animation>(); 
        Animation randAnim = gameObject.GetComponent<Animation>();

        GameObject gb = Instantiate(teleportEffect, character.transform.position, character.transform.rotation);
        gb.transform.SetParent(character.transform);
        anim.Play("TeleportAnim");
        randAnim.Play("TeleportAnim");
        Invoke("Tele", 0.6f);




    }

    public void Tele()
    {
        int move = CharacterController2D.m_FacingRight ? 50 : -50;
        controller.Move(move, false, false);
    }

    public void RandomSwords()
    {
        Vector3 center = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        center.z = 0;

        for (int i = 0; i < 6; i++)
        {
            int random = UnityEngine.Random.Range(0, 46);
            Vector3 pos = RandomCircle(center, 2.5f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);

            GameObject clone = (Instantiate(swordPrefab, pos, swordPrefab.transform.rotation * rot)) as GameObject;
            clone.GetComponent<OneSword>().center = center;

            clone.GetComponent<SpriteRenderer>().sprite = swords[random];

            GameObject spellCir = Instantiate(spellCircle, pos, rot);

            GameObject swordSpriteM = Instantiate(swordSpriteMask, pos, rot);
            Destroy(clone, 2);
            Destroy(spellCir, 0.5f);
            Destroy(swordSpriteM, 0.5f);

        }

    }


    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = UnityEngine.Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    //void Shoot ()
    //{
    //    Debug.Log("Test");
    //}
}
