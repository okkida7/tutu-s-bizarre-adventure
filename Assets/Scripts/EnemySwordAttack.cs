using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public int damage = 3;
    public float flashTime;
    Animator anim;
    public LayerMask playerLayer;
    public Transform leftAttackPoint;
    public Transform rightAttackPoint;
    public float attackRange = 0.5f;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        Collider2D[] hit = Physics2D.OverlapCircleAll(rightAttackPoint.position, attackRange, playerLayer);
        foreach(Collider2D other in hit){
            if(other.tag == "Player"){
                PlayerController player = other.GetComponent<PlayerController>();
                if(player != null) {
                    player.Health -= damage;
                    player.FlashColor(flashTime);
                    player.HealthUI();
                }
            }
        }
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        Collider2D[] hit = Physics2D.OverlapCircleAll(leftAttackPoint.position, attackRange, playerLayer);
        foreach(Collider2D other in hit){
            if(other.tag == "Player"){
                PlayerController player = other.GetComponent<PlayerController>();
                if(player != null) {
                    player.Health -= damage;
                    player.FlashColor(flashTime);
                    player.HealthUI();
                }
            }
        }
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }


    public void OnDrawGizmosSelected(){
        if(rightAttackPoint == null || leftAttackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(leftAttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(rightAttackPoint.position, attackRange);
    }
}
