using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PauseMenu : ViewBase
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public PauseOptionPanel pauseOptionPanel;
    public PauseMenuPanel pauseMenuPanel;

    void Start(){
        pauseMenuUI.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadOptions(){
        pauseMenuPanel.Hide();
        pauseOptionPanel.Show();
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
