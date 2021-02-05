using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuadCreatorSr : MonoBehaviour
{
    public GameObject QuadPrefab;
    bool gameOver = false;
    public Transform[] spawnPoints;
    public Text Score;
    public Text FinalScore;
    public int scoreCount;
    public GameObject GameOver;

    public static int highScoreC;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        //InvokeRepeating("CreateQuad", 0.1f, 0.5f);
        StartCoroutine(CreateQuads());

    }

    void Update()
    {

        if (scoreCount > QuadCreatorSr.highScoreC)
        {
            QuadCreatorSr.highScoreC = scoreCount;

            PlayerPrefs.SetInt("highscoreC", QuadCreatorSr.highScoreC);
        }
        scoreCount = quad.score1 + quadSliced.score2;
        Score.text = "Score: " + scoreCount;
    }

    IEnumerator CreateQuads()
    {
        while (!gameOver)
        {
            //MeshRenderer qsx = QuadPrefab.GetComponent<MeshRenderer>();
            float delay = Random.Range(0.1f, 1f);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
           
            Instantiate(QuadPrefab, spawnPoint.position, spawnPoint.rotation);
            /*MeshRenderer tsx = thisone.GetComponent<MeshRenderer>();
            tsx.material.color = Color.red;*/


        }
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("New Scene");
    }


    public void onExit()
    {
        GameOver.SetActive(true);
        FinalScore.text = "YOUR SCORE: " + scoreCount;
        gameOver = true;
    }

    void CreateQuad()
    {
        if (!gameOver)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-3f, 3f), -7.5f, 1f);
            GameObject gobj = Instantiate(QuadPrefab, spawnPoint, transform.rotation);
            Destroy(gobj, 3f);
          
        }
    }

}
