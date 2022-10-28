using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmonster : MonoBehaviour
{
    public GameObject marshmonster;
    public PlayerController playerController;
    public Transform player;
    public float radius;
    public float range;

    public MarshmonsterAttack marshmonsterAttack;
    public EventTriggerThree worldEventTrigger;
    public GameObject enemyAttack;

    Animator anim;
    Collider2D collider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = (transform.position - player.position).sqrMagnitude;
        if (distance < range)
        {
            if(playerController.movementInput == Vector2.zero || playerController.canMove == false)
                transform.position = new Vector2((player.position.x), (player.position.y + 0.2f));
                anim.SetBool("Disappear", false);
                anim.SetBool("isUnder", false);
                anim.SetBool("isIdle", true);
                if (distance < radius)
                {
                    //collider.enabled = true;
                    enemyAttack.SetActive(true);
                    anim.SetBool("isAttacking", true);
                }
                else
                {
                    EndAttack();
                }
                worldEventTrigger.ActivateBossFight();
        }
        else if (playerController.movementInput != Vector2.zero && distance < range)
        {
            //collider.enabled = true;
            worldEventTrigger.ActivateBossFight();
            Invoke("Disappear", 3f); 
        }
        else
        {
            //collider.enabled = false;
            worldEventTrigger.BossHasBeenDefeated();
            anim.SetBool("isUnder", true);
        }
    }

    void EndAttack()
    {
        enemyAttack.SetActive(false);
        anim.SetBool("isAttacking", false);
        Disappear();
    }

    void Disappear()
    {
        enemyAttack.SetActive(false);
        anim.SetBool("Disappear", true);
        anim.SetBool("isUnder", true);
    }

    public void EnemySwordAttack()
    {
        marshmonsterAttack.Attack();
    }

    public void EnemyEndSwordAttack()
    {
        marshmonsterAttack.StopAttack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
