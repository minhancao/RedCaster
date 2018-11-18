using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject lightningEffect;
    public int destroyTime = 5;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer != 11 && hitInfo.gameObject.layer != 18)
        {
            Debug.Log(hitInfo.GetType());
            Instantiate(lightningEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
