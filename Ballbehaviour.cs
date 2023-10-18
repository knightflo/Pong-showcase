using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Ballbehaviour : MonoBehaviour
{
    public float xPosition = -4f;
    public float yPosition = -3f;
    public float xSpeed = 3f;
    public float ySpeed = 3f;
    public Scoremanager scoreManager;
    public int youWinScore;
    public AudioClip beep;
    public AudioClip boop;
    public AudioClip die;
    public GameObject ball;
    void resetBall()
    {
        xPosition = -4f;
        yPosition = -3f;
        xSpeed = 3f;
        ySpeed = 3f;
    }
    // Start is called before the first frame update
    void Start()
    {

        resetBall();
        transform.position = new Vector3(xPosition, yPosition, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
        // Update variable with +1;
        xPosition += xSpeed * Time.deltaTime;
        yPosition += ySpeed * Time.deltaTime;
        transform.position = new Vector3(xPosition, yPosition, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnumerator waitAFewSeconds(float seconds)
        {
            AudioSource.PlayClipAtPoint(die, transform.position);
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("Win");
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (collision.gameObject.CompareTag("Paddle"))
        {
            xSpeed *= -1.1f;
            ySpeed *= 1.1f;
            AudioSource.PlayClipAtPoint(beep, transform.position);
        }
        else if (collision.gameObject.CompareTag("yCollider"))
        {
            ySpeed *= -1f;
            AudioSource.PlayClipAtPoint(boop, transform.position);
        }
        else if (collision.gameObject.CompareTag("rightCollider"))
        {

            resetBall();
            //When right wall is hit add score to left player
            scoreManager.addScore("left");
            AudioSource.PlayClipAtPoint(die, transform.position);
        }
        else if (collision.gameObject.CompareTag("leftCollider"))
        {
            if (!SceneManager.GetSceneByName("Survival").isLoaded)
            {



                resetBall();
                //When left wall is hit add score to right player
                scoreManager.addScore("right");
                AudioSource.PlayClipAtPoint(die, transform.position);
            } 
            
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            xSpeed *= -1.1f;
            ySpeed *= 1.1f;
            
        }
        if (scoreManager.leftScore >= youWinScore)
        {
            scoreManager.youWin("Left");
            
        }
        else if (scoreManager.rightScore >= youWinScore)
        {
            scoreManager.youWin("Right");
            
        }

    }
}
