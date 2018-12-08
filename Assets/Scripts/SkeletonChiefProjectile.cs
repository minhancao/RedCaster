using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChiefProjectile : MonoBehaviour {

    public float radius = 3;
    float angle;
    public float speed = (2 * Mathf.PI) / 5;

    GameObject player;
    GameObject chief;
    Vector3 circleCenter;
    Vector3 vectorToTarget;
    //Vector3 storedTarget;

    [SerializeField]
    float attackTimer = 10;
    [SerializeField]
    float readyTimer = 1f;





	// Use this for initialization
	void Start () {
        player = GameObject.Find("Character");
        chief = GameObject.Find("SkeletonChief");

        // calculate offset
        angle = Mathf.PI / 2 - speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (attackTimer < 0 )
        {
            Debug.Log("attacking");
            attack();
        }
        else
        {
            aimAtPlayer();
            circularMove();
            attackTimer -= Time.deltaTime;
        }
	}
    void attack() {
        if (readyTimer < 0)
        {
            //float step = 6f * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, storedTarget, step);
            transform.position += vectorToTarget.normalized * 0.5f;
        }
        else
        {
            readyTimer -= Time.deltaTime;
        }
    }


    void aimAtPlayer() {
        //storedTarget = player.transform.position;
        vectorToTarget = player.transform.position - transform.position;
        float rotationAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 33;
        Quaternion quaternion = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime * 2f );

    }

    void circularMove()
    {
       
        circleCenter = chief.transform.position;
        angle += speed * Time.deltaTime;

        float _x = Mathf.Cos(angle) * radius + circleCenter.x;
        float _y = Mathf.Sin(angle) * radius + circleCenter.y;
        Vector3 _pos = new Vector3(_x, _y, 0);
        gameObject.transform.position = _pos;


    }
}
