using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySeamonster : Enemy
{
    public float patrolSpeed;
    public float chasingSpeed;
    public float patrolWaitTime;
    private float waitTime;
    public float radius;
    public float attackRange;
    private float animTime;
    public float setAnimTime;
    private float Cd;
    public float setCD;
    private bool Attack;
    public EnemySwordAttack swordAttack;
    public EventTriggerOne worldEventTrigger;
    public GameObject enemyAttack;


    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    private Transform playerTransform;

    Animator anim;
    SpriteRenderer spriteRenderer;

    public void Start()
    {
        waitTime = patrolWaitTime;
        movePos.position = GetRandomPos();
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (distance < radius)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
                {
                    Attacking();
                }
                else
                {
                    enemyAttack.SetActive(false);
                    anim.SetBool("isAttacking", false);
                    GoToTarget();
                }
                worldEventTrigger.ActivateBossFight();
            }
            else
            {
                worldEventTrigger.BossHasBeenDefeated();
                anim.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, movePos.position, patrolSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
                {
                    if (waitTime <= 0)
                    {
                        movePos.position = GetRandomPos();
                        waitTime = patrolWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                        anim.SetBool("isRunning", false);
                    }
                }
                if ((movePos.position.x - transform.position.x) > 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if ((movePos.position.x - transform.position.x) < 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

    private void Attacking()
    {
        anim.SetBool("isRunning", false);
        //this.spriteRenderer.flipX = playerTransform.transform.position.x < this.transform.position.x; 
        if (animTime >= 0)
        {
            if (Cd <= 0)
            {
                enemyAttack.SetActive(true);
                Attack = true;
                anim.SetBool("isAttacking", Attack);
                animTime -= Time.deltaTime;
                Cd = setCD;
            }
            else
            {
                Cd -= Time.deltaTime;
            }
            if (animTime < setAnimTime)
            {
                animTime -= Time.deltaTime;
            }
        }
        else
        {
            animTime = setAnimTime;
            enemyAttack.SetActive(false);
            Attack = false;
            anim.SetBool("isAttacking", Attack);
        }
    }


    private void GoToTarget()
    {
        anim.SetBool("isRunning", true);
        this.spriteRenderer.flipX = playerTransform.transform.position.x > this.transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chasingSpeed * Time.deltaTime);
    }

    public void EnemySwordAttack()
    {
        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackRight();
        }
        else
        {
            swordAttack.AttackLeft();
        }
    }

    public void EnemyEndSwordAttack()
    {
        swordAttack.StopAttack();
    }

    public void OnDrawGizmosSelected()
    {
        if (transform.position == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
