using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButtons : MonoBehaviour
{
    #region

    Transform btn_logo;
    Image btn_bg;
    Sprite btn_normal_sprite;
    public Sprite HightedSprite;

    #endregion

    #region 

    // Start is called before the first frame update
    void Start()
    {
        //btn_logo = transform.Find("btn_logo");
        //btn_logo.gameObject.SetActive(false);

        btn_bg = transform.GetComponent<Image>();
        btn_normal_sprite = btn_bg.sprite;
    }

    #endregion

    #region 

    public void OnPointerEnter(){
        SetHighlight(true);
    }

    public void OnPointerExit(){
        SetHighlight(false);
    }

    public void OnPointerUp(){
        SetHighlight(false);
    }

    #endregion

    #region 
    
    public void SetHighlight(bool light){
        //btn_logo.gameObject.SetActive(light);
        btn_bg.sprite = light ? HightedSprite : btn_normal_sprite;
    }

    #endregion
}
