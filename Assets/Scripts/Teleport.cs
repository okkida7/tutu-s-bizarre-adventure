using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : ViewBase
{
    public GameObject portal;
    private GameObject player;
    public Enemy enemy;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            if(enemy.bossDefeated>=1){
                player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            } 
        }
    }
}
