using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public string[] dialog;
    private int index;

    public float wordSpeed;

    public GameObject contButton;

    private void Update()
    {
        if (dialogText.text == dialog[index])
        {
            contButton.SetActive(true);
        }
    }

    public void Typing()
    {
        dialogText.text = dialog[index];
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            Typing();
        }
        else
        {
            zeroText();
        }
    }

    public void zeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Typing();
            dialogPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zeroText();
        }
    }
}
