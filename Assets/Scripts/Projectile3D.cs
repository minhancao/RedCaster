using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3D : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject projectileEffect;

    public void reverseVelo()
    {
        if (projectileEffect != null)
        {
            Instantiate(projectileEffect, transform.position, transform.rotation);
        } 
        if (rb != null)
          rb.velocity *= -1;

    }
}
