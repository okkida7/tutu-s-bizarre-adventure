using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerOne : MonoBehaviour
{
    public UIBossHealth bossHealth;
    public EBMA boss;

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
        bossHealth.SetUIHealthBarToActive1();
    }

    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        bossHealth.SetHealthBarToInactive1();
    }
}

