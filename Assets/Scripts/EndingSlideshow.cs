using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSlideshow : MonoBehaviour
{
    public void GoToCredit()
    {
        SceneManager.LoadScene(4);
    }
}
