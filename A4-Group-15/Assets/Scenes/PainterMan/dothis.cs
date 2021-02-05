using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dothis : MonoBehaviour
{
    public GameObject brushBlue;
    public GameObject brushRed;
    public GameObject brushYellow;
    public GameObject brushGreen;

    bool isBlue = false;
    bool isRed = false;
    bool isYellow = false;
    bool isGreen = false;

    public GameObject GameOver;
    public Text Score;
    public Text currentScore;
    int countObjects=0;

    bool gameOver;

    public static int highScoreP;

    void Start()
    {
        gameOver = false;
        GameOver.SetActive(false);
        isBlue = true;
    }


    public void setBlue()
    {
        isBlue = true;
         isRed = false;
         isYellow = false;
        isGreen = false;

    }

    public void setRed()
    {
        isRed = true;
         isBlue = false;
         isYellow = false;
         isGreen = false;
    }


    public void setGreen()
    {
        isGreen = true;
         isBlue = false;
         isRed = false;
         isYellow = false;
    }


    public void setYellow()
    {
        isYellow = true;
         isBlue = false;
         isRed = false;
         isGreen = false;
    }

    public void onExit()
    {
        gameOver = true;
        GameOver.SetActive(true);
        Score.text = "YOUR SCORE: " + countObjects;

    }

    public void OnMenu()
    {
        SceneManager.LoadScene("New Scene");
    }


    // Update is called once per frame
    void Update()
    {

        if (countObjects > dothis.highScoreP)
        {
            dothis.highScoreP = countObjects;

            PlayerPrefs.SetInt("highscoreP", dothis.highScoreP);
        }
        if (!gameOver)
        {
            currentScore.text = "SCORE: " + countObjects;
            if (Input.GetMouseButton(0))
            {
                if (isBlue)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        var go = Instantiate(brushBlue, hit.point + Vector2.up * 0.1f, Quaternion.identity, transform);
                        countObjects++;
                    }
                }
                if (isRed)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        var go = Instantiate(brushRed, hit.point + Vector2.up * 0.1f, Quaternion.identity, transform);
                        countObjects++;
                    }
                }
                if (isGreen)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        var go = Instantiate(brushGreen, hit.point + Vector2.up * 0.1f, Quaternion.identity, transform);
                        countObjects++;
                    }
                }
                if (isYellow)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        var go = Instantiate(brushYellow, hit.point + Vector2.up * 0.1f, Quaternion.identity, transform);
                        countObjects++;
                    }
                }
            }
        }
    }
}
