using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionPanel : ViewBase
{
    #region 
    public PauseMenu pauseMenu;
    public PauseMenuPanel pauseMenuPanel;
    public OptionAudioSetPanel optionAudioSetPanel;
    public OptionOperatorPanel optionOperatorPanel;

    GameObject btn_audio;
    GameObject btn_operator;
    GameObject messagepanel;

    #endregion

    #region 
    private void Start(){
        btn_audio = transform.Find("bg/btn_sound").gameObject;
        btn_operator = transform.Find("bg/btn_controls").gameObject;
    }
    #endregion


    #region 

    public void OnAudioClick(){
        btn_audio.SetActive(false);
        btn_operator.SetActive(false);
        pauseMenuPanel.Hide();
        optionAudioSetPanel.Show();

    }
    public void OnOperatorClick(){
        HideOrShowOptionPanel(false);
        pauseMenuPanel.Hide();
        optionOperatorPanel.Show();

    }
    public void OnBackClick(){
        if (optionAudioSetPanel.IsShow() || optionOperatorPanel.IsShow()){
            optionOperatorPanel.Hide();
            optionAudioSetPanel.Hide();
            HideOrShowOptionPanel(true);
        }
        else {
            this.Hide();
            pauseMenu.Show();
            pauseMenuPanel.Show();
        }
    }
    #endregion

    #region 
    void HideOrShowOptionPanel(bool isShow){
        btn_audio.SetActive(isShow);
        btn_operator.SetActive(isShow);
    }
    #endregion
}
