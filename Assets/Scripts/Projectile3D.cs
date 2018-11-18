using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3D : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject projectileEffect;

    //private void OnTriggerEnter2D(Collider2D hitInfo)
    //{

    //    //if (hitInfo.gameObject.layer == 18)
    //    //{
    //    //    Instantiate(projectileEffect, transform.position, transform.rotation);
    //    //    rb.velocity *= -1;
    //    //

    //}

    public void reverseVelo()
    {
        if (projectileEffect != null)
        {
            Instantiate(projectileEffect, transform.position, transform.rotation);
        } 
        rb.velocity *= -1;

    }
}
