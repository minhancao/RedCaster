using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject frostEffect;
    public int destroyTime = 5;
    public float angle = 1f;

    // Use this for initialization
    void Start()
    {
        rb.velocity = (transform.right + new Vector3(0, angle, 0)) * speed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.layer != 11 && hitInfo.gameObject.layer != 18 && hitInfo.gameObject.layer != 19)
        {
            Instantiate(frostEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
