using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebBlock : MonoBehaviour
{
    public bool isOpen;

    void Awake(){
        isOpen = false;
    }
    void Update(){
        if(isOpen){
            Destroy(gameObject);
        }
    }
}
