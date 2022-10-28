using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour{
    public Collider2D swordCollider;
    public int damage = 3;
    public float flashTime;
    Vector2 rightAttackOffset;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(1, 0);
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(-9, 0);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null) {
                enemy.health -= damage;
                enemy.FlashColor(flashTime);
            }
        }
    }
}
