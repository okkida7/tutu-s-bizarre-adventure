using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportFail : MonoBehaviour
{
    public GameObject TeleportUI;
    public Enemy enemy;
    public Enemy enemy2;

    void Start(){
        TeleportUI.SetActive(false);
    }

    void OntriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            if(enemy.bossDefeated + enemy2.bossDefeated < 2){
                print("should show");
                TeleportUI.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }
    }
    IEnumerator WaitForSec(){
        yield return new WaitForSeconds(3f);
        Destroy(TeleportUI);
    }
}
