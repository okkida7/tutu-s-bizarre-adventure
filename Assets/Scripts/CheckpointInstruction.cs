using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointInstruction : MonoBehaviour
{
    public float showTime;
    
    void Update(){
        Invoke("OnEnter", showTime);
    }

    public void OnEnter(){
        transform.gameObject.SetActive(false);
    }
}
