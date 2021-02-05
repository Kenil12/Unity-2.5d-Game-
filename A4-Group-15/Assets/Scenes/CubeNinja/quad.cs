using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quad : MonoBehaviour
{
    public GameObject QuadSlicedPrefab;

    Vector3 bar;
    Rigidbody2D rb;
    public static int score1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
        
    }



    void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log("We hit it"); 
        if (col.gameObject.tag == "Blade")
        {
            ++quad.score1;
            Debug.Log("score 1: " + quad.score1);
            //Debug.Log(gameObject.transform.position);
            bar = gameObject.transform.position;
            Vector3 direction = (col.gameObject.transform.position - gameObject.transform.position).normalized;
            Quaternion rotater = Quaternion.LookRotation(direction);
            //Debug.Log(rotater.eulerAngles.x);
            rotater.eulerAngles = new Vector3(0, 0, rotater.eulerAngles.x+rotater.eulerAngles.y);
            GameObject cuttedCube = Instantiate(QuadSlicedPrefab, bar, rotater);
            Destroy(cuttedCube, 3f);
            Destroy(gameObject);
        }
    }
}
