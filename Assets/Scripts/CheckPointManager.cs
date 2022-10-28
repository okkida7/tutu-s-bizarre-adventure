using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public CheckPoint positionCheck;
    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;
    public Enemy enemy4;
    public GameObject seamonster;
    public GameObject spider;
    public GameObject marshmonster;
    public GameObject master;
    public GameObject spiderweb;
    public GameObject seamonsterweb;
    public GameObject instruction;
    public PlayerController player;
    public GameObject intro;
    public GameObject guide;

    public void Start(){
        if (PlayerPrefs.GetInt("isRewarded") == 1){
            positionCheck.posX = PlayerPrefs.GetFloat("x");
            positionCheck.posY = PlayerPrefs.GetFloat("y");
            positionCheck.enemy1health = PlayerPrefs.GetInt("one");
            positionCheck.enemy2health = PlayerPrefs.GetInt("two");
            positionCheck.enemy3health = PlayerPrefs.GetInt("three");
            positionCheck.enemy4health = PlayerPrefs.GetInt("four");

            if (PlayerPrefs.HasKey("playerHealth"))
            {
                player.health += PlayerPrefs.GetFloat("playerHealth");
            }
           
            player.grassSound.Pause();
            player.zone1Sound.Pause();
            player.zone2Sound.Pause();
            player.zone3Sound.Pause();
            player.zone4Sound.Pause();

            GameObject.FindGameObjectWithTag("Player").transform.position = 
            new Vector2(positionCheck.posX, positionCheck.posY);
            
            if(positionCheck.enemy1health == 0)
            {
                enemy1.health = positionCheck.enemy1health;
                seamonster.SetActive(false);
                seamonsterweb.SetActive(false);
            }
            if(positionCheck.enemy2health == 0)
            {
                enemy2.health = positionCheck.enemy2health;
                spider.SetActive(false);
                spiderweb.SetActive(false);
            }
            if(positionCheck.enemy3health == 0)
            {
                enemy3.health = positionCheck.enemy3health;
                marshmonster.SetActive(false);
            }
            if(positionCheck.enemy4health == 0)
            {
                enemy4.health = positionCheck.enemy4health;
                master.SetActive(false);
            }
            GameOver.instance.isRewarded = 0;
            PlayerPrefs.SetInt("isRewarded", 0);
        }
        if(PlayerPrefs.GetInt("hideGuide") == 1)
        {
            instruction.SetActive(false);
            intro.SetActive(false);
            Destroy(guide);
        }
        else
        {
            instruction.SetActive(true);
            intro.SetActive(true);
        }
    }
}
