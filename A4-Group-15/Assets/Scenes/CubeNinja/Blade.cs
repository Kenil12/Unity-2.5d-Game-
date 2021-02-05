using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    bool cutting = false;
    BoxCollider2D bb;
    Rigidbody2D rb;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cutting = false;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        bb = GetComponent<BoxCollider2D>();
        bb.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bb.enabled = true;
            Cut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            bb.enabled = false;
            PauseCut();
        }
        if (cutting)
        {
            updateCut();
        }

        void updateCut()
        {
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        void Cut()
        {
            cutting = true;
        }

        void PauseCut()
        {
            cutting = false;
        }
    }
}
