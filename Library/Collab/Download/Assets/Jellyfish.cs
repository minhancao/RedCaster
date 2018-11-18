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

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Pulse", startTime, repeatRate);
        rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (rb.velocity.magnitude > maxSpeed) {
        //    rb.velocity = rb.velocity.normalized * maxSpeed;
        //}	
	}
    void Pulse() {
        rb.AddForce(velocity);
        rb.drag = 0;
    }
}
