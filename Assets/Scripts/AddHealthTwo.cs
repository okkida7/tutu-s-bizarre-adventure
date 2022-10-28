using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthTwo : MonoBehaviour
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
            healthPickupNumber = 2;
            PlayerPrefs.SetInt("healthPickupTwo", healthPickupNumber);
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
