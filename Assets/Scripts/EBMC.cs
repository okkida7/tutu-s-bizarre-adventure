using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBMC : MonoBehaviour
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
        bossHealth.SetBoss3Name(bossName);
        bossHealth.SetBossMaxHealth3(enemy.health);
    }

    public void UpdateBossHealthBar(float currentHealth)
    {
        bossHealth.SetBossCurrentHealth3(currentHealth);
    }
}
