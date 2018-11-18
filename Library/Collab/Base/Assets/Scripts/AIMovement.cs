﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    public float runSpeed = 40f;
    public float horizontalMove = 1f;

    public bool followPlayer = false;




    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void FixedUpdate()
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !m_FacingRight)
        {
            // ... flip the player.
            flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight)
        {
            // ... flip the player.
            flip();
        }



    }
    private void flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool wallDetected = false;
        // Checking Normals

        //foreach (ContactPoint2D contact in collision.contacts) {
        // Visualize the contact point
        ContactPoint2D contact = collision.GetContact(collision.contacts.Length-1);
            Debug.Log("Contact Normal: " + contact.normal);

            if (!m_FacingRight)
            {
                if (contact.normal == Vector2.right)
                {
                    wallDetected = true;
                }
            }
            else
            {
                if (contact.normal == Vector2.left)
                {
                    wallDetected = true;
                }
            }

        //}
        if (wallDetected) {
            horizontalMove *= -1;
            flip();
        }
    }

}