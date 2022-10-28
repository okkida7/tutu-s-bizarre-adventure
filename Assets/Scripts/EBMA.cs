using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBMA : MonoBehaviour
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
        bossHealth.SetBoss1Name(bossName);
        bossHealth.SetBossMaxHealth1(enemy.health);
    }

    public void UpdateBossHealthBar(float currentHealth)
    {
        bossHealth.SetBossCurrentHealth1(currentHealth);
    }
}
