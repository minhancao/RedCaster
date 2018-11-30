using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChief : MonoBehaviour
{
    [SerializeField]
    int phase = 0;

    [SerializeField]
    BossEnemy stats;

    [SerializeField]
    Animator animator;

    [SerializeField]
    SkeletonChiefProjectile projectile;

    // Phase 0 summon monster
    public Transform SummonWolfTransform1;
    public Transform SummonWolfTransform2;
    public bool monstersKilled = false;
    public bool monstersSummoned = false;

    // Phase 1 circular movement
    bool _atCenter = false;
    bool _walked = false;
    bool _started = false;
    bool _movedUp = false;
    int _numProjectiles = 10;
    int _numRotations = 0;
    public Transform circleCenter;
    float radius = 2.5f;
    float angle = 0;
    float speed = (2 * Mathf.PI) / 7; // 5 seconds to complete a circle
    float step = 0.05f;

    public Transform SummonProjectileTransform;

    // Phase 2 Laser attack
    [SerializeField]
    private float _spawnTimeDelay = 0.482f;

    [SerializeField]
    private float laserTimer = 5.0f;

    [SerializeField]
    private float laserChargeTimer = 2.0f;

    [SerializeField]
    private float laserCooldownTimer = 10.0f;
    private bool firing = false;


    public GameObject Player;

    public GameObject wolf;

    // Update is called once per frame
    void Update()
    {
        if (Player.gameObject.transform.position.x <= gameObject.transform.position.x)
        {
            animator.SetBool("FacingLeft", true);
        }
        else
        {
            animator.SetBool("FacingLeft", false);
        }
        switch (phase)
        {
            case 0:
                animator.SetBool("isWalking", false);
                if(!monstersSummoned){
                    SummonMonsters();
                    monstersSummoned = true;
                }
                if (stats.health <= stats.TotalHealth * .8 )
                {
                    phase = 1;
                }
                break;
            case 1:
                if (stats.health <= stats.TotalHealth * .5 )
                {
                    phase = 2;
                }
                // if it hasn't walked to the cneter before, and is not currently at the center
                // walk to center
                if (!_walked && !_atCenter)
                {
                    animator.SetBool("isWalking", true);
                    if (transform.position == circleCenter.position){
                        _walked = true;
                        _atCenter = true;
                    }
                    else
                        transform.position = Vector3.MoveTowards(transform.position, circleCenter.position, step);

                    //_atCenter = walkToCenter();
                }
                else // if it has walked or is currently at center, begin circular move
                {
                    animator.SetBool("isWalking", false);
                    circularMove();
                }
                break;
            case 2:
                animator.SetTrigger("Attack");
                laserAttack();
                break;

        }
    }

    void teleportToPosition() {
        if (!firing)
        {
            laserCooldownTimer -= Time.deltaTime;
            if (laserCooldownTimer < 0){
                gameObject.transform.position = new Vector3(27, Player.transform.position.y, 0);
            }
        }
    }
    void laserAttack()
    {
        if (firing)
        {
            laserTimer -= Time.deltaTime;

            if (laserTimer < 0)
            {
                Debug.Log("Stopping laser");
                Debug.Log("Reseting Cooldown");
                laserCooldownTimer = 10.0f;
                //stopLaser;
            }
        }
        else
        {
            laserChargeTimer -= Time.deltaTime;
            
            if(laserChargeTimer < 0){
                firing = true;
                Debug.Log("Firing laser");
                //fireLaser();
            }

        }
    }

    void SummonMonsters()
    {
        animator.SetTrigger("Attack");
        Instantiate(wolf, SummonWolfTransform1.position, transform.rotation);
        Instantiate(wolf, SummonWolfTransform2.position, transform.rotation);
    }
    IEnumerator SummonProjectiles()
    {
        for (int i = 0; i < _numProjectiles; i++){
            Instantiate(projectile, SummonProjectileTransform, transform);
            yield return new WaitForSeconds(_spawnTimeDelay);
        }
    }
    bool walkToCenter()
    {
        if (nearlyEqual(gameObject.transform.position.x, circleCenter.position.x, 0.01f))
        {
            animator.SetTrigger("Attack");
            
            _walked = true;
            return true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, circleCenter.position, step);

            float _x;

            if (circleCenter.position.x - gameObject.transform.position.x > 0)
            {
                _x = gameObject.transform.position.x + 0.03f;
            }
            else
            {
                _x = gameObject.transform.position.x - 0.03f;
            }
            Vector3 _pos = new Vector3(_x, circleCenter.position.y, 0);
            gameObject.transform.position = _pos;

            return false;
        }
    }

    // move to above the pivot, then rotate around pivot
    void circularMove()
    {

        // supposedly move the skeleton to above hte circle center by the radius amount
        if (!_movedUp)
        {
            Vector3 _pos = new Vector3(circleCenter.position.x, circleCenter.position.y + radius, circleCenter.position.z);
            if(_pos == transform.position){
                _movedUp = true;
                StartCoroutine("SummonProjectiles");
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, _pos, step);
            }

            //// 0.1f is a substitute for speed
            //float _y = 0.03f + gameObject.transform.position.y;
            //Vector3 _pos = new Vector3(circleCenter.x, _y, 0);
            //gameObject.transform.position = _pos;

            //if (_pos.y >= circleCenter.y + radius)
            //{
            //    Debug.Log("target met");
            //    _movedUp = true;
            //    Debug.Log("Spawning Projectiles");
            //    StartCoroutine("SummonProjectiles");
            //}
        }
        // rotate around circle center
        else
        {

            angle += speed * Time.deltaTime;
            if (_started)
            {
                float _x = Mathf.Cos(angle) * radius + circleCenter.position.x;
                float _y = Mathf.Sin(angle) * radius + circleCenter.position.y;
                Vector3 _pos = new Vector3(_x, _y, 0);
                gameObject.transform.position = _pos;
            }
            if (nearlyEqual(Mathf.Cos(angle), 0f, 0.01f) && nearlyEqual(Mathf.Sin(angle), 1f, 0.01f)){
                if(_started){
                    _numRotations += 1;
                }
                else
                    _started = true;
            }
        }
    }

    // compares floating point values with margin of error, epsilon
    bool nearlyEqual(float a, float b, float epsilon)
    {
        float absA = Mathf.Abs(a);
        float absB = Mathf.Abs(b);
        float diff = Mathf.Abs(a - b);

        if (a == b)
        {
            return true;
        }
        else if (a == 0 || b == 0 || diff < Mathf.Abs(float.MinValue)) {
            return diff < epsilon;
        }
        else {
            return diff / (absA + absB) < epsilon;
        }
    }
}
