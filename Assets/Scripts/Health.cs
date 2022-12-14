using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    PlayerController player;

    public void Start(){
        player = GetComponent<PlayerController>();
    }

    public void Update(){
        if(player.Health>numOfHearts){
            player.Health = numOfHearts;
        }
        for(int i = 0; i<hearts.Length; i++){
            if(i<player.Health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }
    }
}
