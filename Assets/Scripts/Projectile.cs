using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public float damage;
    public int webRange;
    public GameObject enemyAttack;

    void Start(){
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Health -= damage;
            player.FlashColor(1f);
            player.HealthUI();
        }
        if (hitInfo.tag == "Player")
        {
            enemyAttack.SetActive(true);
            Destroy(gameObject);
            enemyAttack.SetActive(false);
        }
        if (hitInfo.tag == "OuterZone2")
        {
            Destroy(gameObject);
        }
    }
}
