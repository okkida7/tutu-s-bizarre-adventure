using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuPanel : ViewBase
{
    #region
    public OptionPanel optionPanel;
    #endregion

    #region 

    public void OnStartGameClick() {
        // TODO
    }

    public void OnOptionClick() {
        //Hide self
        this.Hide();
        //Show option
        optionPanel.Show();
    }

    public void OnExitClick() {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    #endregion
}
