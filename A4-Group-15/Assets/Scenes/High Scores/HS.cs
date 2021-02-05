using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HS : MonoBehaviour
{
    public Text Score;
    public Text ScoreP;
    public Text ScoreC;

    public void Start()
    {
        BubbleMaker.highScoreB = PlayerPrefs.GetInt("highscore", BubbleMaker.highScoreB);
        Score.text = "Bubble-Burster: " + BubbleMaker.highScoreB.ToString();

        dothis.highScoreP = PlayerPrefs.GetInt("highscoreP", dothis.highScoreP);
        ScoreP.text = "Painter-Man: " + dothis.highScoreP.ToString();

        QuadCreatorSr.highScoreC = PlayerPrefs.GetInt("highscoreC", QuadCreatorSr.highScoreC);
        ScoreC.text = "Cube-Ninja: " + QuadCreatorSr.highScoreC.ToString();
    }
    public void Back()
    {
        SceneManager.LoadScene("New Scene");
    }



}
