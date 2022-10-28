using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : ViewBase
{   
    // Start is called before the first frame update
    public GameObject attack;
    public GameObject esc;
    public GameObject A;
    public GameObject D;
    public GameObject S;
    public GameObject W;

    void Start()
    {
        attack = GameObject.Find("/Player/Instructions/J");
        esc = GameObject.Find("Player/Instructions/Esc");
        A = GameObject.Find("Player/Instructions/A");
        D = GameObject.Find("Player/Instructions/D");
        S = GameObject.Find("Player/Instructions/S");
        W = GameObject.Find("Player/Instructions/W");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)){
            A.SetActive(false);
            D.SetActive(false);
            S.SetActive(false);
            W.SetActive(false);
            attack.SetActive(true);
            esc.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.Escape)){
            Destroy(attack);
            Destroy(esc);
        }
    }
}
