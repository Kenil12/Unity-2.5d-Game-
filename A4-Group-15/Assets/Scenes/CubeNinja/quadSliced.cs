using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadSliced : MonoBehaviour
{
    public GameObject QuadSlicedMorePrefab;
    public static int score2;
    Vector3 bar;

    Rigidbody2D rb;
    void Start()
    {
    }

    void increaseScore()
    {
        quadSliced.score2 = quadSliced.score2 + 2;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("quad be slicing");
        if (col.gameObject.tag == "Blade")
        {
            increaseScore();
            Debug.Log("score2: " + quadSliced.score2);
            //Debug.Log(gameObject.transform.position);
            bar = gameObject.transform.position;
            Vector3 direction = (col.gameObject.transform.position - gameObject.transform.position).normalized;
            Quaternion rotater = Quaternion.LookRotation(direction);
            //Debug.Log(rotater.eulerAngles.x);
            rotater.eulerAngles = new Vector3(0, 0, rotater.eulerAngles.x + rotater.eulerAngles.y);
            GameObject cuttedCube = Instantiate(QuadSlicedMorePrefab, bar, rotater);
            Destroy(cuttedCube, 3f);
            Destroy(gameObject);
        }
    }
}
