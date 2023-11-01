using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tilat jossa hämis voi olla
public enum SpiderState{
    idle,
    attack,
    walking,
    stop
}

// liikuttaa hämähäkkiä kohti heroa sekä ruiskaisee myrkkyä heron päälle jos hero on liian lähellä

public class SpiderController : MonoBehaviour
{
    const int CHASEDISTANCE = 20;
    const int ATTACKDISTANCE = 7;

    [SerializeField] Transform player;

    [SerializeField] int spiderSpeed;
    Animator spiderAnim;
    Vector3 direction;
    [SerializeField] SpiderState spiderState;

    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject poison;

    private void Awake() {
        spiderAnim = GetComponent<Animator>();
        spiderState = SpiderState.idle;
    }
    
    private void FixedUpdate() {
        direction = player.position - transform.position;

        if(Vector3.Distance(player.position, transform.position) < CHASEDISTANCE){
            HandleAnimationMovementInArea();
        }
        else {
            HandleAnimationMovementOutArea();
        }
    }

// toiminnot kun pelihahmo on jahtialueella
    private void HandleAnimationMovementInArea(){
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.05f);

        spiderAnim.SetBool("isIdle", false);

        if(direction.magnitude > ATTACKDISTANCE){
            transform.Translate(0,0, 0.05f);
            spiderAnim.SetBool("isAttacking", false);
            spiderAnim.SetBool("isWalking", true);
            spiderState = SpiderState.walking;

        }
        else{
            spiderAnim.SetBool("isAttacking", true);
            spiderAnim.SetBool("isWalking", false);
            spiderState = SpiderState.attack;
        }
    }

// toiminnot kun pelihahmo on jahtialueen ulkopuolella
    private void HandleAnimationMovementOutArea(){
        spiderAnim.SetBool("isWalking", false);
        spiderAnim.SetBool("isIdle", true);
        spiderAnim.SetBool("IsAttacking", false);
        spiderState = SpiderState.idle;
    }

    public void DealDamage(){
        ShootPoison();
    }

    private void ShootPoison(){
        AudioManager.instance.Play("SpiderHit");
        GameObject poisonClone = Instantiate(poison, shootingPoint.position, shootingPoint.rotation);
        Destroy(poisonClone, 1.0f);

    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, CHASEDISTANCE);
    }
}
