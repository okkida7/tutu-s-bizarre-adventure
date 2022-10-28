using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBMB : MonoBehaviour
{
    public string bossName;

    UIBossHealth bossHealth;
    Enemy enemy;

    private void Awake()
    {
        bossHealth = FindObjectOfType<UIBossHealth>();
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        bossHealth.SetBoss2Name(bossName);
        bossHealth.SetBossMaxHealth2(enemy.health);
    }

    public void UpdateBossHealthBar(float currentHealth)
    {
        bossHealth.SetBossCurrentHealth2(currentHealth);
    }
}
