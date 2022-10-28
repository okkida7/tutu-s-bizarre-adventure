using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class OpeningSlideshow : MonoBehaviour
{
    public void GoToStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

 
}
