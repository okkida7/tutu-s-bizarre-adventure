using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEvent : MonoBehaviour
{
    public Enemy enemy;
    public EventTriggerOne ET1;
    public EventTriggerTwo ET2;
    public EventTriggerThree ET3;
    public EventTriggerFour ET4;

    private void Update()
    {
        if (enemy.health <= 0)
        {
            if(ET1 != null)
            {
                ET1.BossHasBeenDefeated();
            }

            if(ET2 != null)
            {
                ET2.BossHasBeenDefeated();
            }

            if(ET3 != null)
            {
                ET3.BossHasBeenDefeated();
            }

            if(ET4 != null)
            {
                ET4.BossHasBeenDefeated();
            }
        }

    }
}
