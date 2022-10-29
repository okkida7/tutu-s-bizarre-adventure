using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthThree : MonoBehaviour
{
    PlayerController player;
    public int healthAdding;
    public int healthPickupNumber;

    bool isColliding;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding) return;
        isColliding = true;
        if (other.tag == "Player")
        {
            healthPickupNumber = 10;
            PlayerPrefs.SetInt("healthPickupThree", healthPickupNumber);
            player = other.GetComponent<PlayerController>();
            player.Health += healthAdding;
            PlayerPrefs.SetFloat("playerHealth", player.Health);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        isColliding = false;
    }
}
