using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {

    public bool DEBUG;
    public GameObject projectilePrefab;
    public Transform projectilePoint;
    public int projectileSpeed;

    [SerializeField]
    private float startTime;
    [SerializeField]
    private float periodTime;
	
    // Use this for initialization
	void Start () {
        InvokeRepeating("FireProjectile", startTime, periodTime);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {

    }

    private void FireProjectile() {
        var projectile = (GameObject)Instantiate(projectilePrefab, projectilePoint);

        GameObject player = GameObject.Find("Character");
        if (player != null){
            Vector2 player_pos = player.GetComponent<Rigidbody2D>().position;
            Vector2 current_pos = gameObject.GetComponent<Rigidbody2D>().position;
            float dx = player_pos.x - current_pos.x;
            float dy = player_pos.y - current_pos.y;

            Vector2 vector = new Vector2(dx, dy);
            vector.Normalize();

            projectile.GetComponent<Rigidbody2D>().velocity = vector * projectileSpeed;

            if (DEBUG) Debug.Log("(dx,dy): (" + dx +", " + dy+ " )");
        }


        
    }
}
