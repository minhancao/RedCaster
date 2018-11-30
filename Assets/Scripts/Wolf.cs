using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : AIMovement {

    [SerializeField]
    Animator animator;

    GameObject character;

    [SerializeField]
    float attackDelay;

    [SerializeField]
    float checkPeriod;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float jumpForce;

    //bool _isAttacking;

    float _x;
    float dist;

    // Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
        StartCoroutine("checkPlayerProximity");
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_FacingRight = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("Speed", m_Rigidbody2D.velocity.magnitude);
        animator.SetBool("FacingRight", m_FacingRight);
    }

    IEnumerator checkPlayerProximity()
    {
        while (true){
            dist = Vector3.Distance(gameObject.transform.position, character.transform.position);
            Debug.Log("checking Player Proximity");

            if (dist < attackRange)
            {
                Debug.Log("Player within range");
                Bite();
                yield return new WaitForSeconds(attackDelay);
            }
            yield return new WaitForSeconds(checkPeriod);
        }
    }
    void Bite() {
        animator.SetTrigger("Attack");

        if (gameObject.transform.position.x > character.transform.position.x)
            m_Rigidbody2D.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
        else
            m_Rigidbody2D.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
    }
}
