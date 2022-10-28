using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpiderControl : MonoBehaviour
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
    public EBMB enemyBossManagerTwo;

    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private void Start()
    {
        bossHealth.SetBossMaxHealth2(health);
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        Invoke("setFalse", 3f);
        if (spiderWebBlock != null)
        {
            SpiderWebBlock();
        }
        if (moveToEnding != null)
        {
            Invoke("MoveToEnding", 3f);
        }
    }


    public void SpiderWebBlock()
    {
        spiderWebBlock.isOpen = true;
    }

    public void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }

    public void MoveToEnding()
    {
        moveToEnding.isOpen = true;
    }

    public void setFalse()
    {
        gameObject.SetActive(false);
        bossDefeated += 1;
    }

    public void Update()
    {
        enemyBossManagerTwo.UpdateBossHealthBar(health);
    }
}
