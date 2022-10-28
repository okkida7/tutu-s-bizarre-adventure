using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBossHealth : MonoBehaviour
{
    public TMP_Text[] bossName;
    public Slider[] slider;

    private void Awake()
    {
        SetHealthBarToInactive1();
        SetHealthBarToInactive2();
        SetHealthBarToInactive3();
        SetHealthBarToInactive4();
    }

    private void Start()
    {
        slider[0].gameObject.SetActive(false);
        slider[1].gameObject.SetActive(false);
        slider[2].gameObject.SetActive(false);
        slider[3].gameObject.SetActive(false);
    }

    public void SetBoss1Name(string name)
    {
        bossName[0].text = name;
    }

    public void SetBoss2Name(string name) {
        bossName[1].text = name;
    }

    public void SetBoss3Name(string name) {
        bossName[2].text = name;
    }

    public void SetBoss4Name(string name) { 
        bossName[3].text = name;
    }

    public void SetUIHealthBarToActive1()
    {
        slider[0].gameObject.SetActive(true);
    }

    public void SetUIHealthBarToActive2() {
        slider[1].gameObject.SetActive(true);
    }

    public void SetUIHealthBarToActive3() {
        slider[2].gameObject.SetActive(true);
    }

    public void SetUIHealthBarToActive4() { 
        slider[3].gameObject.SetActive(true);
    }

    public void SetHealthBarToInactive1()
    {
        slider[0].gameObject.SetActive(false);
    }

    public void SetHealthBarToInactive2() {
        slider[1].gameObject.SetActive(false);
    }

    public void SetHealthBarToInactive3() {
        slider[2].gameObject.SetActive(false);
    }

    public void SetHealthBarToInactive4() { 
        slider[3].gameObject.SetActive(false);
    }

    public void SetBossMaxHealth1(float maxHealth)
    {
        slider[0].maxValue = maxHealth;
        slider[0].value = maxHealth;
    }

    public void SetBossMaxHealth2(float maxHealth) {
        slider[1].maxValue = maxHealth;
        slider[1].value = maxHealth;
    }

    public void SetBossMaxHealth3(float maxHealth) {
        slider[2].maxValue = maxHealth;
        slider[2].value = maxHealth;
    }

    public void SetBossMaxHealth4(float maxHealth) { 
        slider[3].maxValue = maxHealth;
        slider[3].value = maxHealth;
    }

    public void SetBossCurrentHealth1(float currentHealth)
    {
        slider[0].value = currentHealth;
    }

    public void SetBossCurrentHealth2(float currentHealth) {
        slider[1].value = currentHealth;
    }

    public void SetBossCurrentHealth3(float currentHealth) {
        slider[2].value = currentHealth;
    }

    public void SetBossCurrentHealth4(float currentHealth) { 
        slider[3].value = currentHealth;
    }

    public void DestroyAll()
    {
        Destroy(slider[0].gameObject);
        Destroy(slider[1].gameObject);
        Destroy(slider[2].gameObject);
        Destroy(slider[3].gameObject);
    }
}

