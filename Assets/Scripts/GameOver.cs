using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : ViewBase
{
    public int isRewarded = 0;
    public static GameOver instance;

    public void Awake(){
        if(instance != null){
            return;
        }
        instance = this;
        PlayerPrefs.SetInt("hideGuide", 0);
    }

    public void RestartButton(){
        PlayerPrefs.SetInt("isRewarded", 1);
        PlayerPrefs.SetInt("hideGuide", 1);
        SceneManager.LoadScene(2);
    }


    public void ExitButton(){
        SceneManager.LoadScene(1);
    }
    
}
