using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public TMP_Text score;
    public GameObject ball;
    public void addScore(string leftOrRight)
    {
        if (leftOrRight == "left")
        {
            leftScore++;
        }
        else if (leftOrRight == "right")
        {
            rightScore++;
        }
        score.text = "Score \n" + leftScore + " - " + rightScore;
    }
    public void youWin(string leftOrRight)
    {
        score.text = leftOrRight + " wins!\n";
        StartCoroutine(waitAFewSeconds(3f));
    }
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score \n" + leftScore + " - " + rightScore;
    }
    IEnumerator waitAFewSeconds (float seconds)
    {
        Destroy(ball);
        yield return new WaitForSeconds (seconds);
        SceneManager.LoadScene("win");
    }
}
