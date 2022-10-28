using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneManager : MonoBehaviour
{
    public Enemy enemy;
    public GameObject windZone;

    void Update()
    {
        if(enemy.health <= 0)
        {
            if (windZone != null)
            {
                windZone.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
