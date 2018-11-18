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

    //void Shoot ()
    //{
    //    Debug.Log("Test");
    //}
}
