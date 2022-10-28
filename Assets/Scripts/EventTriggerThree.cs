using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerThree : MonoBehaviour
{
    public UIBossHealth bossHealth;
    public EBMC boss;

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
        bossHealth.SetUIHealthBarToActive3();
    }

    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        bossHealth.SetHealthBarToInactive3();
    }
}

