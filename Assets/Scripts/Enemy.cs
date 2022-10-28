using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    Animator animator;    
    public float health;
    public float damage;
    private SpriteRenderer sr;
    private Color originalColor;
    public SpiderWebBlock spiderWebBlock;
    public float bossDefeated;
    public MoveToEnding moveToEnding;
    public UIBossHealth bossHealth;
    public EBMA enemyBossManagerOne;
    public EBMB enemyBossManagerTwo;
    public EBMC enemyBossManagerThree;
    public EBMD enemyBossManagerFour;
    public GameObject attackSound;
    Rigidbody2D rb;

    private void Awake() {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        originalColor = sr.color;
    }

    private void Start()
    {
        bossHealth.SetBossMaxHealth1(health);
        bossHealth.SetBossMaxHealth2(health);
        bossHealth.SetBossMaxHealth3(health);
        bossHealth.SetBossMaxHealth4(health);
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
        if (attackSound != null)
        {
            attackSound.SetActive(false);
        }
        Invoke("setFalse", 3f);
        if(spiderWebBlock != null)
        {
            SpiderWebBlock();
        }
        if(moveToEnding != null)
        {
            Invoke("MoveToEnding", 3f);
        }
    }


    public void SpiderWebBlock(){
        spiderWebBlock.isOpen = true;
    }

    public void FlashColor(float time){
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    public void ResetColor(){
        sr.color = originalColor;
    }
    
    public void MoveToEnding(){
        moveToEnding.isOpen = true;
    }

    public void setFalse()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.SetActive(false);
        bossDefeated += 1;
    }

    public void Update()
    {
        if (health <= 0)
        {
            Defeated();
        }
        if (enemyBossManagerOne != null)
        {
            enemyBossManagerOne.UpdateBossHealthBar(health);
        }

        if(enemyBossManagerTwo != null)
        {
            enemyBossManagerTwo.UpdateBossHealthBar(health);
        }

        if(enemyBossManagerThree != null)
        {
            enemyBossManagerThree.UpdateBossHealthBar(health);
        }

        if(enemyBossManagerFour != null)
        {
            enemyBossManagerFour.UpdateBossHealthBar(health);
        }
        
    }
}
