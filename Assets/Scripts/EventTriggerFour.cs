using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerFour : MonoBehaviour
{
    public UIBossHealth bossHealth;
    public EBMD boss;

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
        bossHealth.SetUIHealthBarToActive4();
    }

    public void BossHasBeenDefeated()
    {
        bossHasBeenDefeated = true;
        bossFightIsActive = false;
        bossHealth.SetHealthBarToInactive4();
    }
}

