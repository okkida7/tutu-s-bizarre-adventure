using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToEnding : MonoBehaviour
{
    public bool isOpen;
    public GameObject BGM;
    public GameObject whiteScreen;

    void Awake(){
        isOpen = false;
    }
    void Update(){
        if(isOpen){
            BGM.SetActive(false);
            whiteScreen.SetActive(true);
            Invoke("Move", 3f);
        }
    }
    void Move(){
        SceneManager.LoadScene(3);
    }
}
