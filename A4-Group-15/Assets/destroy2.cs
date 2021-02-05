using UnityEngine;
using UnityEngine.UI;

public class destroy2 : MonoBehaviour
{
    int missedCount = 0;

    public Text Missed;
    public bool gameOver = false;
    public GameObject CanvasGameOver;
    public float timeRemaining = 10;
    public Text Timex;

    void Start()
    {
        CanvasGameOver.SetActive(false);
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            double timeR = System.Math.Round(timeRemaining, 2);
            Timex.text = "Time: " + timeR;
        }
        else
        {
            gameOver = true;
            CanvasGameOver.SetActive(true);
        }

        Missed.text = "Missed: " + missedCount;

        if(missedCount >= 10)
        {
            gameOver = true;
            CanvasGameOver.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bub")
        {
            Debug.Log("Missed Destroyed");
            Destroy(collision.collider.gameObject);
            ++missedCount;
            Debug.Log(missedCount);
        }
    }
}
