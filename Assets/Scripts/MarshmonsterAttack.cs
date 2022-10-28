using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmonsterAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public int damage = 1;
    public float flashTime;
    Animator anim;
    public LayerMask playerLayer;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        swordCollider.enabled = true;
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D other in hit)
        {
            if (other.tag == "Player")
            {
                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.Health -= damage;
                    player.FlashColor(flashTime);
                    player.HealthUI();
                }
            }
        }
    }


    public void StopAttack()
    {
        swordCollider.enabled = false;
    }


    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
