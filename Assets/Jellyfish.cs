using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour {
    Rigidbody2D rb;

    [SerializeField]
    private float startTime;
    [SerializeField]
    private float repeatRate;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private Vector3 velocity;

    [SerializeField]
    private float periodMultiplier;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(velocity.normalized * moveSpeed * Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup * periodMultiplier)));
        rb.drag = 0;


        // This applies a force equal and opposite to the foce that exceeds the maximum speed
        if (rb.velocity.magnitude > maxSpeed){
            float opMag = rb.velocity.magnitude-maxSpeed;
            rb.AddForce(rb.velocity.normalized * opMag * -1);
        }

    }

}
