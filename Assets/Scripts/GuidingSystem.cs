using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuidingSystem : MonoBehaviour
{
    public Transform player;
    public Transform guide;
    public Transform noGuide;
    public float distance;
    public TextMeshProUGUI dialogText;
    public GameObject dialogBox;
    public string dialog;
    bool playerInRange;

    private void Update()
    {
        if(Mathf.Abs(player.position.x - noGuide.position.x) <= 1)
        {
            Destroy(dialogBox);
        }
        else
        {
            if ((player.position.x - guide.position.x) <= distance)
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
        
    }

}
