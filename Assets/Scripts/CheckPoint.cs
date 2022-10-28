using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform checkpoint;
    public float posX;
    public float posY;
    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;
    public Enemy enemy4;
    public int enemy1health = 10;
    public int enemy2health = 10;
    public int enemy3health = 10;
    public int enemy4health = 10;
    public Sprite emptyFood;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update(){
        posX = checkpoint.position.x;
        posY = checkpoint.position.y;
        if (enemy1.health <= 0)
        { 
            enemy1health = 0;
        }
        if (enemy2.health <= 0)
        {
            enemy2health = 0;
        }
        if (enemy3.health <= 0)
        {
            enemy3health = 0;
        }
        if (enemy4.health <= 0)
        {
            enemy4health = 0;
        }
    }

    public void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            spriteRenderer.sprite = emptyFood;
            PlayerPrefs.SetInt("hideGuide", 0);
            PlayerPrefs.SetFloat("x",posX);
            PlayerPrefs.SetFloat("y",posY);
            PlayerPrefs.SetInt("one", enemy1health);
            PlayerPrefs.SetInt("two", enemy2health);
            PlayerPrefs.SetInt("three", enemy3health);
            PlayerPrefs.SetInt("four", enemy4health);
        }
    }
}
