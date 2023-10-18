using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Secondsyes : MonoBehaviour
{
    public int seconds = 0;
    public float timer = 0;
    public TMP_Text text;
    public GameObject ball;
    private Boolean yeet = false;
    
    void Update()
    {
        timer += Time.deltaTime;
        text.text = seconds.ToString();
        if (!yeet)
        {

            
            if (timer > 1)
            {
                timer = 0;
                seconds++;
            }
        }
    }
}
