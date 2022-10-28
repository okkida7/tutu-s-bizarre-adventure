using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    public float fadingRate;

    public void Update(){
        if(myUIGroup.alpha >= 0){
            myUIGroup.alpha -= fadingRate;
            if(myUIGroup.alpha >=1){
                transform.gameObject.SetActive(false);
            }
        }
    }
}
