using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTwo : MonoBehaviour
{
    public UIBossHealth bossHealth;
    public EBMB boss;

    public bool bossFightIsActive;
    public bool bossHasBeenAwakened;
    public bool bossHasBeenDefeated;

    private void Awake()
    {
        bossHealth = FindObjectOfType<UIBossHealth>();
    }

    public void ActivateBossFight()
    {
        bossFightIsActive = true;
        bossHasBeenAwakened = true;
        bossHealth.SetUIHealthBarToActive2();
    }

    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        bossHealth.SetHealthBarToInactive2();
    }
}

