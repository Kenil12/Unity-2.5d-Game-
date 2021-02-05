using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BubbleMaker : MonoBehaviour
{
    [SerializeField]
    GameObject BubblePrefab;

    Rigidbody2D rb;
    int poppedCount = 0;

    public static int highScoreB;


    bool gameOver = false;

    public GameObject d2;
    public Text Popped;
    public Text Score;

    void Start()
    {
        InvokeRepeating("SpawnBubbles", 0.5f, 0.5f);
        rb.gravityScale = -0.1f;
    }

    void SpawnBubbles()
    {
        if (!gameOver)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(4f, -4.0f), -8.0f, -0.03f);
            GameObject obj = Instantiate(BubblePrefab, spawnPoint, transform.rotation);
            rb = obj.GetComponent<Rigidbody2D>();
            rb.gravityScale = rb.gravityScale - 0.1f;
        }
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("New Scene");
    }

    void Update()
    {

        if (poppedCount > BubbleMaker.highScoreB)
        {
            BubbleMaker.highScoreB = poppedCount;

            PlayerPrefs.SetInt("highscore", BubbleMaker.highScoreB);
        }

        if (!gameOver)
        {
            destroy2 ds = d2.GetComponent<destroy2>();
            gameOver = ds.gameOver;
            Popped.text = "Popped: " + poppedCount;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log("Click Destroyed");
                    Destroy(hit.collider.gameObject);
                    ++poppedCount;
                }
            }
        }

        if (gameOver)
        {
            Score.text = "YOUR SCORE: " + poppedCount;
        }
        /*
         //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
         //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        */
    }

}
