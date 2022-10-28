using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBMD : MonoBehaviour
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
        bossHealth.SetBoss4Name(bossName);
        bossHealth.SetBossMaxHealth4(enemy.health);
    }

    public void UpdateBossHealthBar(float currentHealth)
    {
        bossHealth.SetBossCurrentHealth4(currentHealth);
    }
}
