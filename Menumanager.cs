using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    public void loadSceneButton(string nameButton)
    {
        if (nameButton == "classic mode")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (nameButton == ("single mode"))
        {
            SceneManager.LoadScene("SinglePlayer");
        }
        else if (nameButton == ("wall"))
            {
            SceneManager.LoadScene("wall");
        }
        else if (nameButton == ("survival"))
        {
            SceneManager.LoadScene("Survival");
        }
    }
}
