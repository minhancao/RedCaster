using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSword : MonoBehaviour {
    public Vector3 center;
    public GameObject hitEffect;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float step = 8f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, center, step);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("monster1"))
        {
            Debug.Log(hitInfo.GetType());
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
